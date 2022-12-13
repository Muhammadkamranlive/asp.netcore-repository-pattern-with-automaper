using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trevoir.Data;
using Trevoir.IRespository;

namespace Trevoir.Respository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //Add data base connection  to your generic repository by DI

        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Delete(int Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> Query = _dbSet;
            if (includes != null)
            {
                foreach (var queryItem in includes)
                {
                    Query = Query.Include(queryItem);
                }
            }
            return await Query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetALL(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> Includes = null)
        {

            IQueryable<T> Query = _dbSet;
            if (expression != null)
            {
                Query = Query.Where(expression);
            }
            if (orderBy != null)
            {
                Query = orderBy(Query);
            }
            if (Includes != null)
            {
                foreach (var queryItem in Includes)
                {
                    Query = Query.Include(queryItem);
                }
            }
            return await Query.AsNoTracking().ToListAsync();
        }

        public async Task InertMany(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}
