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
        private string GetCoinSummary(string firstCoin, string secondCoin)
        {
            var result = new Response("https://bittrex.com/api/v1.1/public/getmarketsummary?market=" + firstCoin + "-" + secondCoin).Text;
            if (!result.Contains("INVALID_MARKET"))
            {
                return result.Substring(result.IndexOf('[') + 1, result.IndexOf(']') - result.IndexOf('[') - 1);
            }
            else
            {
                return string.Empty;
            }

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
    }
}