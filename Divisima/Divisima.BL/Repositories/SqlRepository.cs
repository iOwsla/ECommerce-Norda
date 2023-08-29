using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Divisima.DAL.Contexts;

namespace Divisima.BL.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        SqlContext db;

        public SqlRepository(SqlContext _db)
        {
            db = _db;
        }

        public async void Add(T entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async void Delete(T entity)
        {
            db.Remove(entity);
            await db.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp);
        }

        public T GetBy(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public async void Update(T entity)
        {
            db.Update(entity);
            await db.SaveChangesAsync();
        }

        public async void Update(T entity, params Expression<Func<T, object>>[] exp)
        {
            if (exp.Any())
                foreach (Expression<Func<T, object>> e in exp)
                {
                    db.Entry(entity).Property(e).IsModified = true;
                }
            else db.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
