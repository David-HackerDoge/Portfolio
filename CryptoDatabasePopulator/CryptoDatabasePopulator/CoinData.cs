using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDatabasePopulator
{
    internal class CoinData
    {
        public string id = "";
        public string rank = "";
        public string symbol = "";
        public string name = "";
        public string supply = "";
        public string maxSupply = "";
        public string marketCapUsd = "";
        public string volumeUsd24Hr = "";
        public string priceUsd = "";
        public string changePercent24Hr = "";
        public string vwap24Hr = "";
        public override string ToString()
        {
            string returnStr = "";
            returnStr += "id: " + id + "\n";
            returnStr += "rank: " + rank + "\n";
            returnStr += "symbol: " + symbol + "\n";
            returnStr += "name: " + name + "\n";
            returnStr += "supply: " + supply + "\n";
            returnStr += "max supply: " + maxSupply + "\n";
            returnStr += "market cap in usd: " + marketCapUsd + "\n";
            returnStr += "volume usd in last 24 hr: " + volumeUsd24Hr + "\n";
            returnStr += "price usd: " + priceUsd + "\n";
            returnStr += "% price change in last 24 hours: " + changePercent24Hr + "\n";
            returnStr += "vwap 24 hr: " + vwap24Hr + "\n";
            return returnStr;
        }
    }
}