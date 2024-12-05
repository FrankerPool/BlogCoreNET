using BlogCoreNET.AccessData.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreNET.AccessData.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this._dbContext = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }
            if (orderBy != null)
            {
                //se ordena y se convierte en lista
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public T GetFisrtOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }

            return query.FirstOrDefault();
        }

        public T GetValue(int id)
        {
            return dbSet.Find(id);
        }

        public void Remove(int idEntity)
        {
            T entity = dbSet.Find(idEntity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
