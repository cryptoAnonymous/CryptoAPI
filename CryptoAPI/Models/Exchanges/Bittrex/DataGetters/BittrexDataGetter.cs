using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CryptoAPI.Models.Entites.Bittrex;
using CryptoAPI.Models.Exchanges.Bittrex.JsonWrappers;
using Newtonsoft.Json;

namespace CryptoAPI.Models.Exchanges.Bittrex.DataGetters
{
    public class BittrexDataGetter
    {
        public BittrexSummaryWrapper GetEntity(string firstCoin, string secondCoin)
        {
            string result = GetCoinSummary(firstCoin, secondCoin);
            if (result != string.Empty)
            {
                return JsonConvert.DeserializeObject<BittrexSummaryWrapper>(result);
            }
            else
            {
                return null;
            }
        }
        public List<BittrexSummaryWrapper> GetEntities()
        {
            IEnumerable<string> jsonCoins = GetCoinSummaries();
            List<BittrexSummaryWrapper> coins = new List<BittrexSummaryWrapper>(100);
            foreach (string jsonCoin in jsonCoins)
            {
                coins.Add(JsonConvert.DeserializeObject<BittrexSummaryWrapper>(jsonCoin));
            }
            return coins;
        }

        public BittrexOrderBookWrapper GetOrdersBook(string coinPair)
        {
            string firstCoin = coinPair.Substring(0, coinPair.IndexOf("-", StringComparison.Ordinal));
            string secondCoin = coinPair.Substring(coinPair.IndexOf("-", StringComparison.Ordinal)+1);
            return GetOrdersBook(firstCoin, secondCoin);
        }
        public BittrexOrderBookWrapper GetOrdersBook(string firstCoin, string secondCoin)
        {
            BittrexOrderBookWrapper result = new BittrexOrderBookWrapper(){MarketName = firstCoin+"-"+secondCoin};
            foreach (var order in GetOrders(firstCoin,secondCoin))
            {
                result.Orders.Add(JsonConvert.DeserializeObject<BittrexOrderWrapper>(order));
            }
            return result;
        }
        private string GetCoinSummary(string firstCoin, string secondCoin)
        {
            var result = new Response("https://bittrex.com/api/v1.1/public/getmarketsummary?market=" + firstCoin + "-" + secondCoin).Text;
            if (!result.Contains("INVALID_MARKET"))
            {
                return result.Substring(result.IndexOf('[') + 1, result.IndexOf(']') - result.IndexOf('[') - 1);
            }
            return string.Empty;
        }

        private IEnumerable<string> GetCoinSummaries()
        {
            List<string> result = new List<string>(100);
            string response = new Response("https://bittrex.com/api/v1.1/public/getmarketsummaries").Text;
            string pattern = "\\{[^}]*\\}";
            Console.WriteLine(pattern);
            foreach (Match match in Regex.Matches(response.Substring(response.IndexOf('[')), pattern))
            {
                result.Add(match.Value);
            }
            return result;
        }

        private IEnumerable<string> GetOrders(string firstCoin, string secondCoin)
        {
            List<string> result = new List<string>(100);
            string response = new Response("https://bittrex.com/api/v1.1/public/getorderbook?market="+firstCoin+"-"+secondCoin+ "&type=both").Text;
            string buys = Regex.Match(response,"buy\".*],").Value;
            string sells = Regex.Match(response, "sell\".*]\\}").Value;

            string pattern = "\\{[^}]*\\}";
            Console.WriteLine(pattern);
            foreach (Match match in Regex.Matches(buys, pattern))
            {
                string order = match.Value.Substring(0, match.Value.Length - 1) + ",\"OrderType\":\""+OrderType.Buy+"\"}";
                result.Add(order);
            }
            foreach (Match match in Regex.Matches(sells, pattern))
            {
                string order = match.Value.Substring(0, match.Value.Length - 1) + ",\"OrderType\":\"" + OrderType.Sell + "\"}";
                result.Add(order);
            }
            return result;
        }
    }
}