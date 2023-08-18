using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto_sim
{
    internal class CryptoCoin
    {
        public Data data = new Data();
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
