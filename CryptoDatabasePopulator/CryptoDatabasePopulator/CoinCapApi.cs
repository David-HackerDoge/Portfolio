using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDatabasePopulator
{
    internal class CoinCapApi
    {
        HttpClient client = new HttpClient();
        /// <summary>
        /// retrieves current crypto coin info using the coincap api and stores it in a CryptoCoin object
        /// includes info like current price in usd, price change percent in last 24 hours, supply, and a timestamp
        /// </summary>
        /// <param name="coinName"></param>
        /// <returns>CryptoCoin requested by coincap api</returns>
        internal CryptoCoin getCoin(string coinName)
        {
            CryptoCoin coin = new CryptoCoin();
            try
            {
                string getUrl = "http://api.coincap.io/v2/assets/";
                getUrl += coinName;
                var task = Task.Run(() => client.GetAsync("http://api.coincap.io/v2/assets/" + coinName));
                //making task synchronous for simplicity
                task.Wait();
                HttpResponseMessage response = task.Result;
                response.EnsureSuccessStatusCode();
                var task2 = Task.Run(async () => await response.Content.ReadAsStringAsync());
                string responseBody = task2.Result;
                coin = JsonConvert.DeserializeObject<CryptoCoin>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine($"Message: {e.Message}\n");
            }
            return coin;
        }
    }
}
