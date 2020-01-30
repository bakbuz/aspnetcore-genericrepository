using ConsoleApp1.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Infrastructure
{
    public class RepositoryImpl<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
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

        public virtual TEntity GetById(int id)
        {
            return Entities.SingleOrDefault(q => q.Id == id);
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
