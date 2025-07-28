using Newtonsoft.Json;

namespace CryptoCurR.Models
{
    public class CoinMarketModel
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal? CurrentPrice { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public decimal? PriceChangePercentage24h { get; set; }

        public decimal? MarketCap { get; set; }
        public int? MarketCapRank { get; set; }
    }
}
