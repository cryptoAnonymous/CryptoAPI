using System.Threading;
using CryptoAPI.Models.Exchanges.Bittrex.DataGetters;

namespace CryptoAPI.Models.DataWrite.Writers
{
    public abstract class Writer
    {
        protected Thread ThreadWriter { get; set; }
        protected BittrexDataGetter DataGetter { get; set; }
        protected BittrexEntityCreator Creator { get; set; }
        public Writer()
        {
            DataGetter = new BittrexDataGetter();
            Creator=new BittrexEntityCreator();
        } 

        public void Start()
        {
            ThreadWriter = new Thread(Write);
            ThreadWriter.Start();
        }

        public void Stop()
        {
            ThreadWriter.Interrupt();
        }
        protected abstract void Write();
    }
}