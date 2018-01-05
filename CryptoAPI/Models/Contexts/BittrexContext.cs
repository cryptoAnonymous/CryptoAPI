using System.Data.Entity;
using CryptoAPI.Models.Contexts.Initializers;
using CryptoAPI.Models.Entites;
using CryptoAPI.Models.Entites.Bittrex;

namespace CryptoAPI.Models.Contexts
{
    public class BittrexContext:DbContext
    {
        static BittrexContext()
        {
            Database.SetInitializer(new BittrexInitializer());
        }
        public static string ExchangeName => "Bittrex";
        public BittrexContext() : base("BittrexContext")
        {
        }

        public DbSet<BittrexSummaryEntity> Summaries { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Market> Markets { get; set; } 
        public DbSet<BittrexOrderBook> OrderBooks { get; set; }
        public DbSet<BittrexOrder> Orders { get; set; }
    }
}