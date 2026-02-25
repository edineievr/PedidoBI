using Microsoft.EntityFrameworkCore;
using PedidosBI.Domain.Application.Services;
using PedidosBI.Domain.Contracts;
using PedidosBI.Infrastructure;
using PedidosBI.Infrastructure.Repositories;
using PedidosBI.Workers.Jobs;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DbContextFactory;
using TickerQ.EntityFrameworkCore.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<Worker>();

var connectionString = "Data Source=PedidosBI_Worker.db;Cache=Shared";
//Registrar DbContext
builder.Services.AddDbContext<TickerQDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

//Registrar TickerQ
builder.Services.AddTickerQ(options =>
{
    options.AddOperationalStore(efOptions =>
    {
        efOptions.UseTickerQDbContext<TickerQDbContext>(dbOptions =>
        {
            dbOptions.UseSqlite(connectionString).EnableSensitiveDataLogging(false).EnableDetailedErrors();
        });
    });
});

//Outros serviços
builder.Services.AddScoped<PedidoBIService>();
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<IPedidoBIRepository, PedidoBIRepository>();
builder.Services.AddScoped<GerarPedidosBIDia>();


var host = builder.Build();

// Seed de dados para testes de BI
using (var scope = host.Services.CreateScope())
{
    if (scope.ServiceProvider.GetRequiredService<IPedidoRepository>() is PedidoRepository repo)
    {
        DataInitializer.Seed(repo);
        Console.WriteLine($"Seed concluído. Pedidos carregados: {repo.GetAll().Count}");
    }
}

using (var scope = host.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TickerQDbContext>();
    context.Database.EnsureCreated();
}

host.UseTickerQ();

host.Run();
