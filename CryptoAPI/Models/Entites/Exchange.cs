using System.Collections.Generic;

namespace CryptoAPI.Models.Entites
{
    public class Exchange
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Market> Markets { get; set; }

        public Exchange()
        {
            Markets=new List<Market>();
        }
    }
}