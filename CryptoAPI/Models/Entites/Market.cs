using System.Collections.Generic;
using CryptoAPI.Models.Entites.Bittrex;

namespace CryptoAPI.Models.Entites
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ExchangeId { get; set; }
        public Exchange Exchange { get; set; }

        public ICollection<BittrexSummaryEntity> Summaries { get; set; }
        public ICollection<BittrexOrderBook> OrderBooks { get; set; }
        public Market()
        {
            Summaries=new List<BittrexSummaryEntity>();
            OrderBooks=new List<BittrexOrderBook>();
        }
    }
}