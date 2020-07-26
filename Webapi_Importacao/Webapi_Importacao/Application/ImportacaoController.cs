using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using Webapi_Importacao.Domain.Entities;
using Webapi_Importacao.Domain.Interface;
using Webapi_Importacao.Service.Validators;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webapi_Importacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportacaoController : Controller
    {
        private IService<Importacao> service;
        Importacao importacao = new Importacao();

        public ImportacaoController(IService<Importacao> _service)
        {
            service = _service;

            //importacao.NomeProduto = "teste1";
            //importacao.DataEntrega  = DateTime.Now ;
            //importacao.Quantidade = 1;
            //importacao.ValorUnitario  = 100.01;

        }

        // GET: api/Importacao
        [HttpGet]
        public ActionResult<IEnumerable<Importacao>> GetImportacoes()
        {
            var retorno = service.Get().OrderBy(x => x.DataEntrega);
            
            return new ObjectResult(retorno);
        }

        // GET: api/Importacao/5
        [HttpGet("{id}")]
        public ActionResult<Importacao> GetImportacao(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // POST: api/Importacao
        [HttpPost]
        public async Task<IActionResult> Insert(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                using (var package = new ExcelPackage(memoryStream))
                {
                    try
                    {
                        for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                        {
                            var totalRows = package.Workbook.Worksheets[i].Dimension?.Rows;
                            var totalCollumns = package.Workbook.Worksheets[i].Dimension?.Columns;

                            for (int j = 2; j <= totalRows.Value; j++)
                            {
                                DateTime dataEntrega;
                                if (DateTime.TryParse(package.Workbook.Worksheets[i].Cells[j, 1].Value.ToString(), out dataEntrega))
                                {
                                    if (dataEntrega < DateTime.Today)
                                        throw new Exception("Data inválida menor que a atual: " + dataEntrega.ToString("dd/MM/yyyy"));
                                }
                                else
                                {
                                    throw new Exception("Data inválida: " + package.Workbook.Worksheets[i].Cells[j, 1].Value.ToString());
                                }

                                
                                if (package.Workbook.Worksheets[i].Cells[j, 2].Value.ToString().Trim().Length > 50)
                                {
                                    throw new Exception("Quantidade de caracteres do campo Descrição maior que 50");
                                }
                                
                                if (Convert.ToInt32(package.Workbook.Worksheets[i].Cells[j, 3].Value.ToString()) < 0 )
                                {
                                    throw new Exception("O campo Quantidade deve ser maior que zeros");
                                }

                                if (Convert.ToDecimal(package.Workbook.Worksheets[i].Cells[j, 4].Value.ToString()) < 0)
                                {
                                    throw new Exception("O campo Valor Unitário deve ser maior que zeros");
                                }

                            }

                            for (int j = 2; j <= totalRows.Value; j++)
                            {
                                importacao = new Importacao();
                                importacao.DataEntrega = Convert.ToDateTime(package.Workbook.Worksheets[i].Cells[j, 1].Value.ToString());
                                importacao.NomeProduto = package.Workbook.Worksheets[i].Cells[j, 2].Value.ToString().Trim();
                                importacao.Quantidade = Convert.ToInt32(package.Workbook.Worksheets[i].Cells[j, 3].Value.ToString());
                                importacao.ValorUnitario = Math.Round(Convert.ToDecimal(package.Workbook.Worksheets[i].Cells[j, 4].Value.ToString()), 2);
                                service.Post<ImportacaoValidator>(importacao);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Erro ao importar tabela: " + ex.Message);
                    }
                    return Content(importacao.NomeProduto);
                }

            }
        }
    }
}
