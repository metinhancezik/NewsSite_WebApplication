using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Concrete;
using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext _context)
        {
            this._context = _context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _context.Set<T>().Where(expression).SingleOrDefault() : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

