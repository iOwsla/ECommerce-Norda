using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Norda.BL.Repositories
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll(); // IQueryable, ICollection, IList, List hepsi IEnumarable'dan türemiştir.
        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp);
        public T GetBy(Expression<Func<T, bool>> exp);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Update(T entity, params Expression<Func<T, object>>[] exp);
        public Task Delete(T entity);
    }
}
