using System.Collections.Generic;

namespace Confitec.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface responsável pelo contrato dos métodos base do respositorio.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
