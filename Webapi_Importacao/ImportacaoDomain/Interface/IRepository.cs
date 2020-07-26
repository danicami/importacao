using System;
using System.Collections.Generic;
using Webapi_Importacao.Domain.Entities;

namespace Webapi_Importacao.Domain.Interface
{
    public interface IRepository<T> where T: BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        T Select(int id);

        IList<T> SelectAll();

    }
}
