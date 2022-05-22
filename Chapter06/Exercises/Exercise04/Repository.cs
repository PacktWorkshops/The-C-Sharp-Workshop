using System.Collections.Generic;
using System.Linq;
using Chapter06.Examples.Repo;
using Microsoft.EntityFrameworkCore;

namespace Chapter06.Exercises.Exercise04
{
    public class Repository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregate
    {
        private readonly DbSet<TAggregate> _dbSet;
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _dbSet = context.Set<TAggregate>();
            _context = context;
        }

        public int Create(TAggregate entity)
        {
            var added = _dbSet.Add(entity);
            _context.SaveChanges();

            return added.Entity.Id;
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

        public void Update(TAggregate entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public TAggregate Get(long id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TAggregate> Get()
        {
            return _dbSet.ToList();
        }
    }
}
