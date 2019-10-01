using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Day
    {
        public Weather weather;
        public List<Customer> customers;
        public int name;
        public Random rand;
        public int crowd;



        public Day(int day)
        {
            name = day;
            weather = new Weather();
            customers = new List<Customer> { };
            crowd = RandomNumber(60, 120);
            MultiplyCustomers();

        }


        public void CreateCustomer()                                                   /////// SINGLE RESPONSIBILITY PRINCIPLE!
        {
            Customer customer = new Customer(weather.condition, weather.temperature);
            customers.Add(customer);
        }


        public void MultiplyCustomers()
        {
            for (int i = 0; i < crowd; i++)
            {
                CreateCustomer();
            }
        }



        public int RandomNumber(int min, int max)        {            rand = new Random();            int num = rand.Next(min, max);            return num;        }






    }

    
    
}
