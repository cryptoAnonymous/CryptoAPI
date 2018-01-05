using System.Data.Entity;
using System.Linq;
using CryptoAPI.Models.DataWrite;
using CryptoAPI.Models.Entites;

namespace CryptoAPI.Models.Contexts.Initializers
{
    public class BittrexInitializer : CreateDatabaseIfNotExists<BittrexContext>
    {
        protected override void Seed(BittrexContext context)
        {
            base.Seed(context);

            if (context.Exchanges.Count(p => p.Name == BittrexContext.ExchangeName) == 0)
            {
                Exchange bittrex = new Exchange { Name = BittrexContext.ExchangeName };
                context.Exchanges.Add(bittrex);
                context.SaveChanges();
            }
        }
    }
}