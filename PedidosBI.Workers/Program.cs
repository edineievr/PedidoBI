using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PedidosBI.Domain.Application.Services;
using PedidosBI.Domain.Contracts;
using PedidosBI.Infrastructure;
using PedidosBI.Infrastructure.Repositories;
using PedidosBI.Workers.Jobs;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DbContextFactory;

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<Worker>();
//Registrar DbContext
builder.Services.AddDbContext<TickerQDbContext>();

//Registrar TickerQ
builder.Services.AddTickerQ().AddEntityFrameworkNpgsql();

//Outros serviços
builder.Services.AddScoped<PedidoBIService>();
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<IPedidoBIRepository, PedidoBIRepository>();
builder.Services.AddScoped<GerarPedidosBIDia>();


var host = builder.Build();

// Seed de dados para testes de BI
using (var scope = host.Services.CreateScope())
{
    var repo = scope.ServiceProvider.GetRequiredService<IPedidoRepository>() as PedidoRepository;
    if (repo != null)
    {
        DataInitializer.Seed(repo);
        Console.WriteLine($"Seed concluído. Pedidos carregados: {repo.GetAll().Count}");
    }
}

host.UseTickerQ();

host.Run();
