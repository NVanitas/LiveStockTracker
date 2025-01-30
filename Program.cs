using StackExchange.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using LiveStockTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration["Redis:ConnectionString"]!));

// Servi�os personalizados
builder.Services.AddSingleton<RedisService>();
builder.Services.AddSingleton<StockService>();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona suporte ao controlador
builder.Services.AddControllers();

var app = builder.Build();

// Habilita o Swagger apenas em ambientes de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiveStockTracker API v1");
        c.RoutePrefix = string.Empty; // Torna o Swagger a p�gina inicial
    });
}

// Mapear os controladores para as rotas
app.MapControllers();

// Iniciar a aplica��o
app.Run();
