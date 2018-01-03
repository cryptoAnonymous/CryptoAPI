using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using CryptoAPI.Models.Exchanges.Bittrex.Entities;
using Newtonsoft.Json;

namespace CryptoAPI.Models.Exchanges.Bittrex.DataGetters
{
    public class BittrexDataGetter
    {
        public BittrexSummaryEntity GetEntity(string firstCoin, string secondCoin)
        {
            string result = GetCoinSummary(firstCoin, secondCoin);
            if (result != string.Empty)
            {
                return JsonConvert.DeserializeObject<BittrexSummaryEntity>(result);
            }
            else
            {
                return null;
            }
        }

        public List<BittrexSummaryEntity> GetEntities()
        {
            IEnumerable<string> jsonCoins = GetCoinSummaries();
            List<BittrexSummaryEntity> coins = new List<BittrexSummaryEntity>(100);
            foreach (string jsonCoin in jsonCoins)
            {
                coins.Add(JsonConvert.DeserializeObject<BittrexSummaryEntity>(jsonCoin));
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
            };
            return result;
        }
    }
}