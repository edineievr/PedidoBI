using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PedidosBI.Domain.Application.Services;
using PedidosBI.Domain.Contracts;
using PedidosBI.Infrastructure;
using PedidosBI.Infrastructure.Context;
using PedidosBI.Infrastructure.Repositories;
using PedidosBI.Workers.Jobs;
using TickerQ.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<PedidoBIService>();

builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<IPedidoBIRepository, PedidoBIRepository>();

//builder.Services.AddDbContext<TickerQContext>(options =>
//                                              options.UseNpgsql("Host=localhost;Port=5432;Database=PedidosBI_Worker;Username=postgres;Password=123"));

builder.Services.AddTickerQ()/*.AddEntityFrameworkNpgsql()*/;

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
