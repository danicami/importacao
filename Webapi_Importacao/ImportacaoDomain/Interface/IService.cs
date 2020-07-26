using FluentValidation;
using System;
using System.Collections.Generic;
using Webapi_Importacao.Domain.Entities;

namespace Webapi_Importacao.Domain.Interface
{
    public interface IService<T> where T: BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);

        T Get(int id);

        IList<T> Get();

    }
}
