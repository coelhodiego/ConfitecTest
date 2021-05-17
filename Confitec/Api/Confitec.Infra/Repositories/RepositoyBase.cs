using Confitec.Domain.Interfaces.Repositories;
using Confitec.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Confitec.Infra.Repositories
{
    /// <summary>
    /// Classe responsável por implementar o contrato do Repositório base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ConfitecContext Db = new ConfitecContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
