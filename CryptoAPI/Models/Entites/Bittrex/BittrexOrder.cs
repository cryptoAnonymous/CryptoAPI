namespace CryptoAPI.Models.Entites.Bittrex
{
    public class BittrexOrder
    {
        public int Id { get; set; }
        public int OrderBookId { get; set; }
        public BittrexOrderBook OrderBook { get; set; }
        public OrderType OrderType { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
    }
}