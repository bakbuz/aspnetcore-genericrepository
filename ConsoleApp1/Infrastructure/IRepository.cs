using ConsoleApp1.Common;
using System.Collections.Generic;

namespace ConsoleApp1.Infrastructure
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        IList<TEntity> GetAll();

        TEntity GetById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
