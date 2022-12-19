using System.Linq.Expressions;

namespace Trevoir.IRespository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetALL(

                Expression<Func<T, bool>> expression = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                List<string> Includes = null
            );
        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task Insert(T entity);
        Task InertMany(IEnumerable<T> entities);
        Task Delete(int Id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
