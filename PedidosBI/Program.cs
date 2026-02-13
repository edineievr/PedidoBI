using PedidosBI.Infrastructure;
using PedidosBI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<PedidoRepository>();//simula banco fake em memoria
builder.Services.AddSingleton<PedidoBIRepository>();//simula banco fake em memoria

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using var scope = app.Services.CreateScope();
var pedidoRepo = scope.ServiceProvider.GetRequiredService<PedidoRepository>();
var pedidoBIRepo = scope.ServiceProvider.GetRequiredService<PedidoBIRepository>();
DataInitializer.Seed(pedidoRepo);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
