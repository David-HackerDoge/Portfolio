using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Sim_Client
{
    internal class SimTest1 : SimProfile
    {
        string name = "defaultName";
        public SimTest1()
        {
        }
        public SimTest1(string name)
        {
            this.name = name;
        }
        public double buy(List<double> prices, double funds)
        {
            return 0;
        }
        public double sell(List<double> prices, double funds)
        {
            return 0;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
    }
}
