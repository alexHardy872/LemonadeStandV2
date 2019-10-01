using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Customer
    {
        public double likelyToBuy;
        private string weather;
        private int temp;
        public bool didBuy;
        

        public Customer(string weather, int temp)
        {
            this.weather = weather;
            this.temp = temp;

        }

        public void CalculateLikelyToBuy(double price)
        {
            double tempFactor = 100 * temp;
            double priceFactor = 100 - price;
            double customerVarietyFactor = UserInterface.RandomNumber(0, 100);
            double weatherFactor = DetermineWeatherFactor();

            likelyToBuy = (tempFactor + weatherFactor + priceFactor + customerVarietyFactor) / 4;
            

            
        }


        public double DetermineWeatherFactor()
        {
            switch (weather)
            {
                case "Snowy":
                    return 10;
                case "Rainy":
                    return 20;
                case "Overcast":
                    return 40;
                case "Clear":
                    return 60;
                case "Sunny":
                    return 90;
                default:
                    return 50;
            }
        }


        public void CustomerApproachesStand()
        {


        }









       

    }
}
