using ConsoleApp2.Common;
using ConsoleApp2.Domain;
using System;
using System.Collections.Generic;

namespace ConsoleApp2.Infrastructure
{
    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        TEntity FindById(int id);
    }

    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IList<TEntity> GetAll();

        TEntity GetById(TPrimaryKey id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
