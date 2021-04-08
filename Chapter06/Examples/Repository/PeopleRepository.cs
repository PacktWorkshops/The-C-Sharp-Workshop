using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter06.Examples.GlobalFactory2021;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Examples.Repository
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(long id);
        void Update(Product product);
        Product Get(long id);
        IEnumerable<Product> Get();
    }

    public interface IManufacturerRepository
    {
        void Create(Manufacturer product);
        void Delete(long id);
        void Update(Manufacturer product);
        Manufacturer Get(long id);
        IEnumerable<Manufacturer> Get();
    }

    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(long id);
        void Update(TEntity entity);
        TEntity Get(long id);
        IEnumerable<TEntity> Get();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }

            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public TEntity Get(long id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }
    }

    public interface IEntity
    {
        long Id { get; }
    }

    public interface IAggregate : IEntity
    {
    }
}
