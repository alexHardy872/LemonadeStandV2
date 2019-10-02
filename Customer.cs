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

        public double CalculateLikelyToBuy()
        {
            double tempFactor = temp;
           
            double customerVarietyFactor = UserInterface.RandomNumber(0, 100);
            double weatherFactor = DetermineWeatherFactor();

            likelyToBuy = (tempFactor + weatherFactor  + customerVarietyFactor) / 3;
            return likelyToBuy;
        }





        public double CombineRecipeeFactors(int lemonsPerPitcher,int sugarCupsPerPitcher, int iceCubesPerCup )
        {
            double recipetotal = CalculateLemonsFactor(lemonsPerPitcher) + CalculateIceFactor(iceCubesPerCup) + CalculateSweetSourRatio(lemonsPerPitcher, sugarCupsPerPitcher) + CalculateSugarFactor(sugarCupsPerPitcher);
            double recipeFactor = (recipetotal / 4);

            return recipeFactor;
        }


        public double CalculateLemonsFactor(int lemonsPerPitcher)
        {
            double lemonsFactor = Convert.ToDouble(UserInterface.Limiter(lemonsPerPitcher * 10, 0, 10));

            return lemonsFactor*10;
        }


        public double CalculateSugarFactor(int sugarCupsPerPitcher)
        {
            double sugarFactor = Convert.ToDouble(UserInterface.Limiter(sugarCupsPerPitcher * 10, 0, 10));

            return sugarFactor*10;
        }


        public double CalculateSweetSourRatio(int lemonsPerPitcher, int sugarCupsPerPitcher)
        {
            double sweetSourFactor;

            if (lemonsPerPitcher == sugarCupsPerPitcher)
            {
                sweetSourFactor = 100;
            }
            else if (lemonsPerPitcher/sugarCupsPerPitcher > 2 || sugarCupsPerPitcher/lemonsPerPitcher >2 )
            {
                sweetSourFactor = 0;
            }
           
            else
            {
                sweetSourFactor = 50;
            }
            return sweetSourFactor;
        }


        public double CalculateIceFactor(int iceCubesPerCup)
        {
            double iceFactor;
            
            int tempRatio = (int)Math.Floor(Convert.ToDouble(temp / 10));

            if (tempRatio == iceCubesPerCup)
            {
                iceFactor = 100;
            }
            else
            {
                iceFactor = 100 - (Math.Abs((tempRatio - iceCubesPerCup) * 10));
            }

            return iceFactor;
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


        public bool CustomerApproachesStand(double price, int ice, int lemons, int sugar)
        {
            double weatherAndPriceFactors = CalculateLikelyToBuy();
            double recipeFactors = CombineRecipeeFactors(lemons, sugar, ice);
            double priceFactor = (1 - price) * 100;

            double likely = (weatherAndPriceFactors * .3) + (recipeFactors * .2) + (priceFactor * .5);

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
