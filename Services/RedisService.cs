using StackExchange.Redis;
using System.Text.Json;

namespace LiveStockTracker.Services
{
    public class RedisService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
        }

        public async Task<T> ObterAsync<T>(string chave)
        {
            var valor = await _database.StringGetAsync(chave);
            if (valor.IsNullOrEmpty) return default;

            return JsonSerializer.Deserialize<T>(valor);
        }

        public async Task SalvarAsync<T>(string chave, T valor, TimeSpan expiracao)
        {
            var valorSerialized = JsonSerializer.Serialize(valor);
            await _database.StringSetAsync(chave, valorSerialized, expiracao);
        }
    }
}
