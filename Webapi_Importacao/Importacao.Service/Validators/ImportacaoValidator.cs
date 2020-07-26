using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi_Importacao.Domain.Entities;

namespace Webapi_Importacao.Service.Validators
{
    public class ImportacaoValidator: AbstractValidator<Importacao>
    {
        public ImportacaoValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Objeto não encontrado.");
                    });

            RuleFor(c => c.DataEntrega)
                .NotEmpty().WithMessage("É necessário informar a Data de Entrega.")
                .NotNull().WithMessage("É necessário informar a Data de Entrega.");

            RuleFor(c => c.NomeProduto)
                .NotEmpty().WithMessage("É necessário informar o Nome.")
                .NotNull().WithMessage("É necessário informar o Nome.");

        }

    }
}
