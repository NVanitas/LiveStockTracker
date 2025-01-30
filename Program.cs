using StackExchange.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using LiveStockTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration["Redis:ConnectionString"]!));

// Serviços personalizados
builder.Services.AddSingleton<RedisService>();
builder.Services.AddSingleton<StockService>();

// Configuração do Swagger
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
        c.RoutePrefix = string.Empty; // Torna o Swagger a página inicial
    });
}

// Mapear os controladores para as rotas
app.MapControllers();

// Iniciar a aplicação
app.Run();
