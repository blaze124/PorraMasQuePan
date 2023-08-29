using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public interface IAppDbContext
    {
        DbSet<Contestant> Contestants { get; }
        DbSet<Match> Matches { get; }
        DbSet<Result> Results { get; }

        DbSet<Championship> Championships { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsyncWithNoAudit(CancellationToken cancellationToken);
        bool IsDisposed();
    }
}
