﻿using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

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

        public double CalculateLikelyToBuy(double price)
        {
            double tempFactor = 100 * temp;
            double priceFactor = 100 - price;
            double customerVarietyFactor = UserInterface.RandomNumber(0, 100);
            double weatherFactor = DetermineWeatherFactor();

            likelyToBuy = (tempFactor + weatherFactor + priceFactor + customerVarietyFactor) / 4;
            return likelyToBuy;
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


        public bool CustomerApproachesStand(double price)
        {
            double likely = CalculateLikelyToBuy(price);
            double chance = UserInterface.RandomNumber(0, 100);
            if (likely < chance) /// is the chance (out of 100) beyond the range they are likely to buy
            {
                didBuy = false;
                return false;
            }
            else
            {
                didBuy = true;
                return true;
            }

        }









       

    }
}
