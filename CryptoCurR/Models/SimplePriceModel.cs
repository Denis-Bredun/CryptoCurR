namespace CryptoCurR.Models
{
    public class SimplePriceModel
    {
        public Dictionary<string, Dictionary<string, decimal>> Prices { get; set; } = new();
    }
} 