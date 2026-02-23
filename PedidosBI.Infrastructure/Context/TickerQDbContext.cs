using Microsoft.EntityFrameworkCore;
using TickerQ.EntityFrameworkCore.DbContextFactory;

namespace PedidosBI.Infrastructure.Context
{
    public class TickerQContext : TickerQDbContext
    {
        public TickerQContext(DbContextOptions<TickerQDbContext> options)
            : base(options)
        {
        }
    }
}