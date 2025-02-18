using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    }
}
