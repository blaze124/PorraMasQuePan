using Application.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Contestant> Contestants {get; set;}

        public DbSet<Match> Matches {get; set;}

        public DbSet<Result> Results {get; set;}

        public DbSet<Championship> Championships { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public Task<int> SaveChangesAsyncWithNoAudit(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool IsDisposed()
        {
            throw new NotImplementedException();
        }
    }
}
