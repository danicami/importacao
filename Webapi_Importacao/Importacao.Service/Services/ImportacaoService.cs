using FluentValidation;
using System;
using System.Collections.Generic;
using Webapi_Importacao.Domain.Entities;
using Webapi_Importacao.Domain.Interface;

namespace Webapi_Importacao.Service.Services
{
    public class ImportacaoService<T> : IService<T> where T : BaseEntity
    {
 
        private readonly IRepository<T> repository;

        public ImportacaoService(IRepository<T> _repository)
        {
            repository = _repository;

        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public IList<T> Get() => repository.SelectAll();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }


    }
}
