using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjackGame.Classes
{
    internal class Bankroll
    {
        private double balance;

        public Bankroll(double startAmount) 
        {
            balance = startAmount;
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }


        public void AddToBalance(double amountToAdd)
        {
            balance += amountToAdd;
        }

        public void RemoveFromBalance(double amountToRemove)
        {
            balance -= amountToRemove;
        }

        public override string ToString()
        {
            return $"${Balance}";
        }
    }
}
