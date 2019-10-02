using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Wallet
    {
        private double money;

        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)

                    money = 0;
                else
                    money = value;
            }
        }


        public Wallet()
        {
            money = 20;
        }


        public bool CheckWallet(double price)        {            if (price > money)            {                return false;            }            else            {                money -= price;                return true;            }        }



    }
}
