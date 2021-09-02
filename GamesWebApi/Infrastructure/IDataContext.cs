using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GamesWebApi.Infrastructure
{
    public interface IDataContext<T> where T : class
    {
        DbSet<T> Games { get;}
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}