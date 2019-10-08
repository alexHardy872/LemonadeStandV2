using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Customer
    {
        public double likelyToBuy;
        private string weather;
        private int temp;
        public bool didBuy;
        public int name;
        

        public Customer(string weather, int temp, int name)
        {
            this.weather = weather;
            this.temp = temp;
            this.name = name;

        }

        public double CalculateTempAndWeatherFactors()
        {
            double tempFactor = temp;
           
            double customerVarietyFactor = UserInterface.RandomNumber(0, 100);
            double weatherFactor = UserInterface.DetermineWeatherFactor(weather);

            likelyToBuy = (tempFactor + weatherFactor  + customerVarietyFactor) / 3;
            return likelyToBuy;
        }





        public double CombineRecipeeFactors(int lemonsPerPitcher,int sugarCupsPerPitcher, int iceCubesPerCup )
        {
            double recipetotal = CalculateLemonsFactor(lemonsPerPitcher) + CalculateIceFactor(iceCubesPerCup) + CalculateSugarFactor(sugarCupsPerPitcher);
            if (lemonsPerPitcher == 0 || sugarCupsPerPitcher == 0)
            {
                recipetotal = 0;
            }
            double recipeFactor = (recipetotal / 3);

            return recipeFactor;
        }



        public double CalculateLemonsFactor(int lemonsPerPitcher)
        {
            double lemonsFactor = Convert.ToDouble(UserInterface.Limiter(lemonsPerPitcher, 0, 10));

            return lemonsFactor*10;
        }



        public double CalculateSugarFactor(int sugarCupsPerPitcher)
        {
            double sugarFactor = Convert.ToDouble(UserInterface.Limiter(sugarCupsPerPitcher, 0, 10));
            
            return sugarFactor*10;
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




        public double LikelynessToBuy(double price, int ice, int lemons, int sugar)
        {
            double weatherAndTempFactors = CalculateTempAndWeatherFactors();
            double recipeFactors = CombineRecipeeFactors(lemons, sugar, ice);
            double priceFactor = 100 - (price * 100);
            double likely = (weatherAndTempFactors * .5) + (recipeFactors * .5);
            likely *= ((priceFactor + 5) / 100);
            if (recipeFactors < 1)
            {
                likely /= 4;
            }

            return likely;
        }


        public bool CustomerApproachesStand(double price, int ice, int lemons, int sugar)
        {
            double likely = LikelynessToBuy(price, ice, lemons, sugar);
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
