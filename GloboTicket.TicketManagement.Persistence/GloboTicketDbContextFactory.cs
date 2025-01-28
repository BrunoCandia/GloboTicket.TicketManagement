using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContextFactory : IDesignTimeDbContextFactory<GloboTicketDbContext>
    {
        public GloboTicketDbContext CreateDbContext(string[] args)
        {
            var configuration = GetConfiguration();

            return CreateDbContext(configuration);
        }

        public static GloboTicketDbContext CreateDbContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GloboTicketDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GloboTicketTicketManagementConnectionString"),
                                           opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds));

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            return new GloboTicketDbContext(optionsBuilder.Options, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        private static IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, true);

            return configurationBuilder.Build();
        }
    }
}
