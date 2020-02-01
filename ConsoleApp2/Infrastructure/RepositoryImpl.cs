using ConsoleApp2.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp2.Infrastructure
{
    public class RepositoryImpl<TEntity> : RepositoryImpl<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public RepositoryImpl(DataContext context)
            : base(context)
        {
        }

        public virtual TEntity FindById(int id)
        {
            return this.Entities.SingleOrDefault(e => e.Id == id);
        }
    }

    public class RepositoryImpl<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly DataContext _context;
        private DbSet<TEntity> _entities;

        public RepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> Table => Entities;

        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();
                return _entities;
            }
        }

        public virtual IList<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public virtual TEntity GetById(TPrimaryKey id)
        {
            Expression<Func<TEntity, bool>> predicate = q => q.Id.Equals(id);
            return Entities.SingleOrDefault(predicate);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }
    }
}
