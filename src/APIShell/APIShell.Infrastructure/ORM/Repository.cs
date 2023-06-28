using APIShell.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.Infrastructure.ORM
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        private readonly TContext _context;

        protected Repository(TContext context)
        {
            this._context = context;
            this._context.Database.SetCommandTimeout(100);
        }

        public void Insert(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(ex.Message);
                }
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
