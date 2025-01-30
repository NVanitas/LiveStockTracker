using StackExchange.Redis;

namespace LiveStockTracker.Services
{
    public class StockService
    {
        private readonly RedisService _redisService;

        public StockService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<decimal> ObterPrecoAcaoAsync(string simbolo)
        {
            var cacheKey = $"stock:{simbolo}";
            var precoCache = await _redisService.ObterAsync<decimal>(cacheKey);

            if (precoCache != default) return precoCache;

            var precoAtual = SimularPrecoAcao();
            await _redisService.SalvarAsync(cacheKey, precoAtual, TimeSpan.FromSeconds(10));
            return precoAtual;
        }
        private decimal SimularPrecoAcao()
        {
            return (decimal)Math.Round(new Random().Next(100, 500) + new Random().NextDouble(), 2);
        }

    }
}
