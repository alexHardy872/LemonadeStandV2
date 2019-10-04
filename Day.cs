using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Day
    {
        public Weather weather;
        public List<Customer> customers;
        public int name;
        public int crowd;



        public Day(int day)
        {
            name = day;
            weather = new Weather();
            customers = new List<Customer> { };
            crowd = GetCrowdSize();
            MultiplyCustomers();

        }

        public int GetCrowdSize()
        {

            double baseCrowd = UserInterface.RandomNumber(75, 120);
            double weatherFactor = UserInterface.DetermineWeatherFactor(weather.condition);
            double newCrowd = Math.Floor(((weatherFactor / 100)*2.2) * baseCrowd);

            int crowdInt = Convert.ToInt32(newCrowd);
            return crowdInt;
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



      






    }

    
    
}
