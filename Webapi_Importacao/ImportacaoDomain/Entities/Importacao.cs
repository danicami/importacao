using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi_Importacao.Domain.Entities
{
    public class Importacao : BaseEntity
    {
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        [NotMapped]
        public decimal ValorTotal
        {
            get { return Math.Round(ValorUnitario * Quantidade, 2); }
        }
    }
}
