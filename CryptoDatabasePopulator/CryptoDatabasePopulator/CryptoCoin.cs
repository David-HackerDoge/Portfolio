using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDatabasePopulator
{
    internal class CryptoCoin
    {
        public CoinData data = new CoinData();
        public string timestamp = "";
        public override string ToString()
        {
            string returnStr = "";
            returnStr += data.ToString();
            returnStr += "time: " + timestamp;

            return returnStr;
        }
    }
}
