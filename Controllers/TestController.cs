using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Binance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://api.binance.com";
        private readonly string _apiVersion = "/api/v3/";

        public TestController()
        {
            _client = new HttpClient();
        }

        [HttpGet("ping")]
        public async Task<string> GetPing()
        {
            var url = Flurl.Url.Combine(_baseUrl, _apiVersion, "ping");
            return await _client.GetStringAsync(url);
        }

        [HttpGet("time")]
        public async Task<string> GetTime()
        {
            var url = Flurl.Url.Combine(_baseUrl, _apiVersion, "time");
            return await _client.GetStringAsync(url);
        }

        [HttpGet("exchangeInfo")]
        public async Task<string> GetExchangeInfo()
        {
            var url = Flurl.Url.Combine(_baseUrl, _apiVersion, "exchangeInfo");
            return await _client.GetStringAsync(url);
        }

        [HttpGet("avgPrice")]
        public async Task<string> GetAvgPrice([Required] string symbol)
        {
            // e.g. LTCBTC (Litecoin  to Bitcoin)
            var url = Flurl.Url.Combine(_baseUrl, _apiVersion, "avgPrice", $"?symbol={symbol}");
            return await _client.GetStringAsync(url);
        }

        [HttpPost("price")]
        public async Task<string> GetPrice(string? symbol)
        {
            // e.g. LTCBTC (Litecoin  to Bitcoin)
            var url = Flurl.Url.Combine(_baseUrl, _apiVersion, "price", (symbol == null ? $"?symbol={symbol}" : ""));
            return await _client.GetStringAsync(url);
        }
    }
}