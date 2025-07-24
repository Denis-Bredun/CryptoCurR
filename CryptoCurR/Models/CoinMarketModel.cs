using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public decimal? PriceChangePercentage24h { get; set; }
        public decimal? MarketCap { get; set; }
        public int? MarketCapRank { get; set; }
    }
}
