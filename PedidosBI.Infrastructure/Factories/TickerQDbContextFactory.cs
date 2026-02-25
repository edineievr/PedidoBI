using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TickerQ.EntityFrameworkCore.DbContextFactory;

namespace PedidosBI.Infrastructure.Factories
{
    public class TickerQDbContextFactory : IDesignTimeDbContextFactory<TickerQDbContext>
    {
        public TickerQDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TickerQDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PedidosBI_Worker;Username=postgres;Password=postgres");
            return new TickerQDbContext(optionsBuilder.Options);
        }
    }
}