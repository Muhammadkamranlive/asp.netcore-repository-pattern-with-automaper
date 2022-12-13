using Trevoir.Data;
using Trevoir.IRespository;

namespace Trevoir.Respository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countryRepository;
        private IGenericRepository<Hotels> _hotelsRepository;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Country> Country => _countryRepository ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Hotels> Hotels => _hotelsRepository ??= new GenericRepository<Hotels>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
