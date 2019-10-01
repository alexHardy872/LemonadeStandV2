using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Customer
    {
        private double likelyToBuy;
        private Random rand;
        private string weather;
        private int temp;

        
        //private List<string> names;
        //public string name;




        public Customer(string weather, int temp)
        {
            this.weather = weather;
            this.temp = temp;

        }










        public int RandomNumber(int min, int max)        {            rand = new Random();            int num = rand.Next(min, max);            return num;        }

    }
}
