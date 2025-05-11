using BookShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    /// <summary>
    /// Kontroler API do konwersji cen na inne waluty
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ExchangeRateService _exchangeService;

        public CurrencyController(ExchangeRateService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> Convert(string pricePln, string targetCurrency)
        {
            try
            {
                var culture = new System.Globalization.CultureInfo("pl-PL");
                var price = decimal.Parse(pricePln, culture);

                var rate = await _exchangeService.GetExchangeRateAsync(targetCurrency);
                var converted = price / rate;

                return Ok(new
                {
                    originalPrice = price,
                    targetCurrency = targetCurrency.ToUpper(),
                    convertedPrice = Math.Round(converted, 2)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
