using System;
using System.Collections.Generic;

namespace Chapter06.Examples.Repo
{
    public interface IRepository<TEntity>: IDisposable where TEntity : class
    {
        int Create(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
    }
}