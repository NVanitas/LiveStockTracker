using Microsoft.AspNetCore.Mvc;
using LiveStockTracker.Services;

namespace LiveStockTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        /// <summary>
        /// Retorna o preço da ação baseado no símbolo fornecido
        /// </summary>
        /// <param name="simbolo">Símbolo da ação (exemplo: AAPL)</param>
        /// <returns>Preço da ação</returns>
        [HttpGet("{simbolo}")]
        public async Task<IActionResult> GetStockPrice(string simbolo)
        {
            var preco = await _stockService.ObterPrecoAcaoAsync(simbolo);
            return Ok(preco);
        }
    }
}
