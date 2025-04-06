using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace BookShop.Services
{
    public class ExchangeRateService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetExchangeRateAsync(string currencyCode)
        {
            var url = $"https://api.nbp.pl/api/exchangerates/rates/A/{currencyCode.ToUpper()}/?format=json";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Nie udało się pobrać kursu waluty: {currencyCode}. Status: {response.StatusCode}");

            var rawJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"[NBP] Response: {rawJson}");

            var result = JsonSerializer.Deserialize<NBPResponse>(rawJson);

            if (result == null || result.Rates == null || result.Rates.Count == 0)
                throw new Exception($"Brak danych kursu dla waluty {currencyCode}.");

            return result.Rates[0].Mid;
        }
    }

    public class NBPResponse
    {
        [JsonPropertyName("rates")]
        public List<NBPRate> Rates { get; set; }
    }

    public class NBPRate
    {
        [JsonPropertyName("mid")]
        public decimal Mid { get; set; }
    }
}
