using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Sim_Client
{
    internal interface SimProfile
    {
        double buy(List<double> prices, double funds);
        double sell(List<double> prices, double funds);
        string getName();
        void setName(string name);
    }
}
