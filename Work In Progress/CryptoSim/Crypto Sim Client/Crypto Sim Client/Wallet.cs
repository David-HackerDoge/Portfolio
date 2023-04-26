using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Sim_Client
{
    internal class Wallet
    {
        double startingCash = 100;
        double currCash = 0;
        double bitcoins = 0;
        DateTime dateMade;
        SimProfile agent;
        public Wallet()
        {
            currCash = startingCash;
            dateMade = DateTime.Now;
            agent = new SimTest1();
        }
        public Wallet(string agentName)
        {
            currCash = startingCash;
            dateMade = DateTime.Now;
            agent = new SimTest1(agentName);
        }
        void setSimProfile(SimProfile agent)
        {
            this.agent = agent;
        }
        void setSimProfile(SimProfile agent, string agentName)
        {
            this.agent = agent;
            this.agent.setName(agentName);
        }
        SimProfile getSimProfile()
        {
            return agent;
        }
        public void buy(bool agent, double bitcoinPrice, List<double> bitcoinPrices, double amount = 0)
        {
            if (agent == false)
            {
                if (amount <= 0)
                {
                    //error. buy more than 0 pls
                }
                else if (amount > 0)
                {
                    double amountToSpend = amount * bitcoinPrice;
                    if (amountToSpend > currCash)
                    {
                        //error. not enough money
                    }
                    else if (amountToSpend <= currCash)
                    {
                        currCash -= amountToSpend;
                        bitcoins += amount;
                    }
                }
            }
            else if (agent == true)
            {
                double amountToBuy = this.agent.buy(bitcoinPrices, currCash);
                if (amountToBuy <= 0)
                {
                    //not buying. just send mssg and exit
                }
                else if (amountToBuy > 0)
                {
                    if (currCash < amountToBuy * bitcoinPrice)
                    {
                        //not enough funds
                    }
                    else if (currCash >= amountToBuy * bitcoinPrice)
                    {
                        currCash -= amountToBuy * bitcoinPrice;
                        bitcoins += amountToBuy;
                    }
                }
            }
        }
    }
}
