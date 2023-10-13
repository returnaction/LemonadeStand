using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Wallet
    {
        // member variables (HAS A)
        private double money;
        public double profit;
        public double Money
        {
            get
            {
                return money;
            }
        }

        //constructor (SPAWNER)
        public Wallet()
        {
            money = 20.00;
        }

        //Member Methods (CAN DO)
        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }

        public void AcceptMoney(double income)
        {
            money += income;
        }
    }
}
