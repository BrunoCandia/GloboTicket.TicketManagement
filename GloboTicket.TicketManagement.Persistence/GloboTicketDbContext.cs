using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string _userName = string.Empty;

        public string UserName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_userName)) return _userName;

                _userName = GetUserName(_httpContextAccessor?.HttpContext);

                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        private static string GetUserName(HttpContext? httpContext)
        {
            string userName = "System";

            if (httpContext is null) return userName;

            ////if (httpContext.User.FindFirst(ClaimTypes.Upn) is not null && httpContext.User.FindFirst(ClaimTypes.Upn)?.Value is not null)
            ////{
            ////    userName = httpContext.User.FindFirst(ClaimTypes.Upn)!.Value!.ToLowerInvariant().Trim();
            ////}
            ////else if (httpContext.User.FindFirst("emails") is not null && httpContext.User.FindFirst("emails")?.Value is not null)
            ////{
            ////    userName = httpContext.User.FindFirst("emails")!.Value!.ToLowerInvariant();
            ////}

            return userName;
        }

        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                //TODO: Review if DateTimeOffset.UtcNow can be synchronized.

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = UserName;
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = UserName;
                        entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
