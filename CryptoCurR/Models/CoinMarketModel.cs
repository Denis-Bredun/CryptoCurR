using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoCurR.Models
{
    public class CoinMarketModel
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? price_change_percentage_24h { get; set; }
        public decimal? MarketCap { get; set; }
        public int? MarketCapRank { get; set; }
    }

    public class Rootobject
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int current_price { get; set; }
        public long market_cap { get; set; }
        public int market_cap_rank { get; set; }
        public long fully_diluted_valuation { get; set; }
        public long total_volume { get; set; }
        public int high_24h { get; set; }
        public int low_24h { get; set; }
        public float price_change_24h { get; set; }
        public float price_change_percentage_24h { get; set; }
        public long market_cap_change_24h { get; set; }
        public float market_cap_change_percentage_24h { get; set; }
        public float circulating_supply { get; set; }
        public float total_supply { get; set; }
        public float max_supply { get; set; }
        public int ath { get; set; }
        public float ath_change_percentage { get; set; }
        public DateTime ath_date { get; set; }
        public float atl { get; set; }
        public float atl_change_percentage { get; set; }
        public DateTime atl_date { get; set; }
        public object roi { get; set; }
        public DateTime last_updated { get; set; }
    }

}
