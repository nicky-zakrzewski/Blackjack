using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjackGame.Classes
{
    internal class Pool
    {
        private double amount;

        public Pool() { amount = 0; }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public void AddToBalance(double amountToAdd)
        {
            amount += amountToAdd;
        }

        public override string ToString()
        {
            return $"${Amount}";
        }
    }
}
