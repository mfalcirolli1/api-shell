using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.Domain.Repository
{
    public interface IRepository<in TEntity> where TEntity : class, new()
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
