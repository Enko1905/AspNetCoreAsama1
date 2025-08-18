using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);



        public IQueryable<T> FindAll(bool TrackChanges)
        {
            if (!TrackChanges)
            {
                return _context.Set<T>().AsNoTracking();
            }
            else
            {
                return _context.Set<T>();
            }
        }

        public IQueryable<T> FindByCondation(Expression<Func<T, bool>> expression, bool TrackChanges)
        {
            if (!TrackChanges)
            {
                return _context.Set<T>().Where(expression).AsNoTracking();
            }
            else
            {
                return _context.Set<T>().Where(expression);
            }
        }


    }
}
