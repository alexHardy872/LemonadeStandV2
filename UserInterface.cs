using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStandV2
{
    public static class UserInterface
    {


        public static void Welcome()
        {            Console.Clear();            Console.WriteLine("Welcome to Lemonade Stand! Press ENTER to begin!");
            Console.ReadLine();            Console.Clear();
        }

        public static void DisplayDay(int currentDay, List<Day> days)
        {
            Console.Clear();
            YellowHighlight("Day " + currentDay+" of "+days.Count);
           

        }

        public static void DisplayMoney(Player player)
        {
            Console.WriteLine("You have $" + FormatDouble(player.wallet.Money));
        }

        public static void DisplayForecast(Day dayIn)
        {
            string forecast = dayIn.weather.SendPredictedWeather();
            Console.WriteLine("Today's forcast is "+forecast);
            
        }

        public static void DisplayWeather(Day dayIn)
        {
            string forecast = dayIn.weather.SendActualWeather();
            Console.WriteLine("Today's weather is " + forecast);

        }

        public static void SevenDayForecast(List<Day> days, int currentDay)
        {
            int daysLeft = days.Count - currentDay;
            int daysAhead = Limiter(daysLeft, 0, 7);
            CenterText("--------------------7 DAY FORECAST----------------------");
            Console.WriteLine("Upcoming weather...");

            if (daysAhead > 1)
            {           
                for (int i = currentDay  ; i < currentDay+daysAhead; i++)
                {
                    if ( i == currentDay)
                    {
                        string forecast = days[i].weather.SendPredictedWeather();
                        YellowHighlight("Day " + (currentDay + 1) + " forecast " + forecast);
                    }
                    else
                    {
                        string forecast = days[i].weather.SendPredictedWeather();
                        Console.WriteLine("Day " + (i + 1) + " forecast " + forecast);
                    }
                           
                }
            }
            if (daysAhead == 1)
            {
                string forecast = days[currentDay].weather.SendPredictedWeather();
                Console.WriteLine("Tomorrow's forecast is " + forecast);
                Console.WriteLine();
            }

            Console.WriteLine("Press ENTER for menu");
            Console.ReadLine();
        }

        public static void YellowHighlight(string input)
        {

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(input+" ");
            Console.ResetColor();
            Console.WriteLine();
        }


      public static void PlayerInfoDisplay(Player player, Day day, List<Day> days)
       {
            
            string forecast = day.weather.predictedForecast;
            int temp = day.weather.predictedTemp;
            DisplayDay(day.name, days);
            Console.WriteLine(String.Format("{0,-30}{1,-30}", "----------------------", "----------------------"));
            Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-10}", "Inventory", "Recipe","Forecast"));
            Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-10}", "----------------------", "----------------------", temp+" and "+forecast));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "cups", player.inventory.cups.Count, "price", "$" + player.recipe.pricePerCup));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "Lemons", player.inventory.lemons.Count, "Lemons", player.recipe.amountOfLemons));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "sugar", player.inventory.sugarCups.Count, "sugar", player.recipe.amountOfSugarCups));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "ice", player.inventory.iceCubes.Count, "ice", player.recipe.amountOfIceCubes));
            Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-10}", "----------------------", "----------------------", "Current Money $" + FormatDouble(player.wallet.Money)));
            Console.WriteLine();
        }


        public static void LiveInfoDisplay(Player player, Day day, List<Day> days, double gross)
        {

            string forecast = day.weather.condition;
            int temp = day.weather.temperature;
            DisplayDay(day.name, days);
            Console.WriteLine(String.Format("{0,-30}{1,-30}", "----------------------", "----------------------"));
            Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-10}", "Inventory", "Recipe", "Weather"));
            Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-10}", "----------------------", "----------------------", temp + " and " + forecast));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "cups", player.inventory.cups.Count, "price", "$" + player.recipe.pricePerCup));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "Lemons", player.inventory.lemons.Count, "Lemons", player.recipe.amountOfLemons));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "sugar", player.inventory.sugarCups.Count, "sugar", player.recipe.amountOfSugarCups));
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "ice", player.inventory.iceCubes.Count, "ice", player.recipe.amountOfIceCubes));
            Console.WriteLine(String.Format("{0,-30}{1,-30}{2,-10}", "----------------------", "----------------------", "Todays money $" + FormatDouble(gross)));
            Console.WriteLine();
        }




        public static void DisplayPostInventory(Player player, Day day, List<Day> days)
        {
           // Console.WriteLine("Here is your remaining Inventory");
            //PlayerInfoDisplay(player, day, days);
            Console.WriteLine("Your remaining ice melted!");
            Console.WriteLine();
            Console.ReadLine();
        }

        public static void DisplayMenu()
        {
            CenterText("-------------------MENU-------------------");
            Console.WriteLine();
            Console.WriteLine("'store' , 'recipe' , 'start' , 'quit', or 'forecast' (7 day forecast)");
            Console.WriteLine();
        }


        public static bool GoodToStart(Player player)
        {
            if (player.inventory.cups.Count == 0)
            {
                Error("WOAH! you have no cups in your inventory! You cant sell ANY lemonade without cups! Check your inventory and go back to the store!");
                return false;
            }
            if (player.recipe.amountOfLemons == 0 || player.recipe.amountOfSugarCups == 0 || player.recipe.amountOfIceCubes == 0)
            {
                string sure = YesOrNo(RetryGetUserInput("One or more items in your recipe have a quantity of ZERO, proceed 'yes' or 'no'?"));
                if (sure == "yes")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (player.inventory.lemons.Count < player.recipe.amountOfLemons || player.inventory.sugarCups.Count < player.recipe.amountOfSugarCups || player.inventory.iceCubes.Count < player.recipe.amountOfIceCubes)
            {
                Error("You have insufficient inventory to use your current recipee! change the recipe or go back to the store!");
                return false;
            }
            return true;
        }

        public static void CenterText(string textIn)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textIn.Length/2)) + "}", textIn));
        }

        public static void RecipeMenuTitle()
        {
            CenterText("--------------------RECIPE MENU----------------------");
            Console.WriteLine();
            

        }

        public static void DisplayStoreMenu()
        {
            CenterText("---------------------STORE MENU----------------------");
            Console.WriteLine();
            Console.WriteLine("What would you like to buy? ('cups', 'lemons' , 'sugar' , 'ice' , or to leave 'done'");
            Console.WriteLine();

        }



        public static void DisplayStoreQuantities(string item, int quant1, int quant2, int quant3, double price1, double price2, double price3)
        {
            Console.WriteLine("What quantity of " + item + " do you want to buy? (enter the number");            Console.WriteLine("Option '1' ( " + quant1 + " for $" + price1+")");            Console.WriteLine("Option '2' ( " + quant2 + " for $" + price2+")");            Console.WriteLine("Option '3' ( " + quant3 + " for $" + price3+")");            Console.WriteLine("or type 'back' to go back to the last menue");

        }

        public static void ConfirmPurchase(string item, int quant, double price, Player player)
        {

            Console.WriteLine("purchased " + quant + " " + item + " for $" + price);
            //Console.WriteLine("remaining money $" + FormatDouble(player.wallet.Money));
        }

     

    



        public static void SoldOut()
            {
            Console.WriteLine("You sold out! Not enough inventory to keep making lemonade!");
            Console.ReadLine();
        }

        public static void DisplayDayResult(int cupsSold, double gross, Day day, int currentDay, Player player)
        {
            Console.Clear();
            Console.WriteLine("DAY " + currentDay + " RESULTS:");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("Sold " + cupsSold + " cups of lemonade to " + day.crowd + " potential customers for a total of $" + FormatDouble(gross));

            double profit = (player.wallet.Money) - 20;
            if (profit > 0)
            {
                Profit(profit);
            }
            else
            {
                Loss(profit);
            }

            Console.WriteLine("Press Enter to advance to next day");
            Console.ReadLine();

 
            }

        



        public static void Profit(double profit)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Total running profit $" + FormatDouble(profit));
            Console.ResetColor();
        }

        public static void Loss (double profit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total running Loss $" + FormatDouble(Math.Abs(profit)));
            Console.ResetColor();
        }



        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }


        public static string RetryGetUserInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            return Console.ReadLine();
        }




        public static int IntGetUserInput(string message)
        {
            int output;
            string test = GetUserInput(message);

            try
            {
                output = Int32.Parse(test);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid number input, please try again");
                Console.ResetColor();

                return IntGetUserInput(message);
            }

            return output;
        }

        public static double GetUserPriceInput(string message)
        {
            double output;
            string test = GetUserInput(message);

            try
            {
                output = Double.Parse(test);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid number input, please try again");
                Console.ResetColor();

                return IntGetUserInput(message);
            }

            output = DLimiter((Math.Floor(output * 100d) / 100d), .01, 1);

            
            return output;
        }




        public static double FormatDouble(double input)
        {
            double output = Math.Floor(input * 100d) / 100d;
            return output;
        }





        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }





        public static void NotEnoughMoney()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You dont have enough money to buy this item");
            Console.ResetColor();
        }

        public static int RandomNumber(int min, int max)
        {
              Random rand = new Random();
                int num = rand.Next(min, max);
                return num;
        }


        public static double DetermineWeatherFactor(string weatherCondition)
        {
            switch (weatherCondition)
            {
                case "Snowy":
                    return 10;
                case "Rainy":
                    return 25;
                case "Overcast":
                    return 50;
                case "Clear":
                    return 65;
                case "Sunny":
                    return 90;
                default:
                    return 50;
            }
        }


        public static int Limiter(int input, int min, int max)
        {
            if (input > max)
            {
                return max;
            }
            else if (input < min)
            {
                return min;
            }
            else
            {
                return input;
            }
            
        }

        public static double DLimiter(double input, double min, double max)
        {
            if (input > max)
            {
                return max;
            }
            else if (input < min)
            {
                return min;
            }
            else
            {
                return input;
            }

        }


        public static void DisplayPurchase(double gross, int name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$$ Customer "+name+" bought lemonade $$ daily total $"+FormatDouble(gross));
            Console.ResetColor();
            Thread.Sleep(100);
        }

        public static void DisplayPass(int name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   Customer "+name+" wasn't interested :( ");
            Console.ResetColor();
            Thread.Sleep(100);
        }




        public static void DisplayTotalProfit(double gross, int days)
        {
            Console.WriteLine("Season Finished!");
            Console.WriteLine();
            Console.Write("In " + days + " days you ");

            if (gross > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Profited $" + gross);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lost $" + Math.Abs(gross)) ;
                Console.ResetColor();
            }
        }


        public static bool PlayAgainMenu()
        {
            string input = YesOrNo(GetUserInput("Play again? 'yes' or 'no'"));

        
            if (input == "yes")
            {
                return true;
            }
            else 
            {
                return false;
            }

        }


        public static string YesOrNo(string input)
        {
            while (input.ToLower() != "yes" && input.ToLower() != "no")
            {
                input = RetryGetUserInput("Must type 'yes' or 'no'");
            }

            return input.ToLower();
        }

        public static void ClearSpace( Player player, Day day, List<Day> days, double gross)
        {

                Console.Clear();
                LiveInfoDisplay(player, day, days, gross);
            
        }

    }
}
