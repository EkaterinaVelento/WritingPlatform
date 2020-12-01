using Base.Abstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace Data
{
    internal abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        private readonly DbContext _context;

        protected Repository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}