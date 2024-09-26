using Microsoft.EntityFrameworkCore;
using Memento.Gpx.Interfaces.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Memento.Gpx.Infrastructures.Data;

namespace Memento.Gpx.Infrastructures.DataLayer
{
    internal abstract class DataLayer <T>(MementoDbContext dbContext) : IDataLayer<T> where T : class
    {
        #region Propriété
        protected DbSet<T> _dbSet = dbContext.Set<T>();
        #endregion

        #region Interface IDataLayer
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual IEnumerable<T> GetAll() => [.. _dbSet];
        //{
        //    return _dbSet.ToList();
        //}

        public T? GetById(int id) => _dbSet.Find(id);
        //{
        //    throw new NotImplementedException();
        //}

        public void Remove(T entity) => _dbSet.Remove(entity);
        //{
        //    throw new NotImplementedException();
        //}

        public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(T entity) => _dbSet.Update(entity);
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

    }
}
