using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll(bool TrackChanges);
        IQueryable<T> FindByCondation(Expression<Func<T,bool>>expression, bool TrackChanges);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
