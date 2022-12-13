using Trevoir.Data;

namespace Trevoir.IRespository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Country { get; }
        IGenericRepository<Hotels> Hotels { get; }
        Task Save();
    }
}
