using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreNET.AccessData.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetValue(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,string? includeProperties = null);
        T GetFisrtOrDefault(Expression<Func<T, bool>>? filter = null,string? includeProperties = null);
        void Add(T entity);
        void Remove(int idEntity);
        void Remove(T entity);

    }
}
