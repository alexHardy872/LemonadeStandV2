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
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Day " + currentDay+" of "+days.Count);
            Console.ResetColor();

        }

        public static void DisplayMoney(Player player)
        {
            Console.WriteLine("You have $" + FormatDouble(player.wallet.Money));
        }

        public static void DisplayForcast(Day dayIn)
        {
            string forcast = dayIn.weather.SendPredictedWeather();
            Console.WriteLine("Today's forcast is "+forcast);
            
        }

        public static void DisplayWeather(Day dayIn)
        {
            string forcast = dayIn.weather.SendActualWeather();
            Console.WriteLine("Today's weather is " + forcast);

        }

        public static void SevenDayForcast(List<Day> days, int currentDay)
        {
            int daysLeft = days.Count - currentDay;
            int daysAhead = Limiter(daysLeft, 0, 7);
            Console.WriteLine("Upcoming weather...");

            if (daysAhead > 1)
            {           
                for (int i = currentDay  ; i < currentDay+daysAhead; i++)
                {
                    string forcast = days[i].weather.SendPredictedWeather();
                    Console.WriteLine("Day " + (i+1) + " forcast " + forcast);           
                }
            }
            if (daysAhead == 1)
            {
                string forcast = days[currentDay].weather.SendPredictedWeather();
                Console.WriteLine("Tomorrow's forcast is " + forcast);
                Console.WriteLine();
            }
        }




        public static void DisplayInventory(Player player)
        {

            Console.WriteLine("Inventory");            Console.WriteLine();            Console.WriteLine(player.inventory.cups.Count + " Cups");            Console.WriteLine(player.inventory.lemons.Count + " Lemons");            Console.WriteLine(player.inventory.sugarCups.Count + " Cups of sugar");            Console.WriteLine(player.inventory.iceCubes.Count + " IceCubes");
            Console.WriteLine();
        }

        public static void DisplayPostInventory(Player player)
        {
            Console.WriteLine("Here is your remaining Inventory");
            DisplayInventory(player);
            Console.WriteLine("Your rmaining ice melted!");
            Console.WriteLine();
            Console.ReadLine();
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("'store' , 'recipe' , 'start' , 'quit', or 'forcast' (7 day forcast)");
            Console.WriteLine();
        }



        public static void DisplayStoreMenu()
        {

            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine();
            Console.WriteLine("Cups? type 'cups'");
            Console.WriteLine("Lemons? type 'lemons'");
            Console.WriteLine("Sugar? type 'sugar'");
            Console.WriteLine("Ice Cubes? type 'ice'");
            Console.WriteLine("Back to game menu? type 'done'");
            Console.WriteLine();

        }

        public static void DisplayStoreQuantities(string item, int quant1, int quant2, int quant3, double price1, double price2, double price3)
        {
            Console.WriteLine("What quantity of " + item + " do you want to buy? (enter the number");            Console.WriteLine("Option '1' ( " + quant1 + " for $" + price1+")");            Console.WriteLine("Option '2' ( " + quant2 + " for $" + price2+")");            Console.WriteLine("Option '3' ( " + quant3 + " for $" + price3+")");            Console.WriteLine("or type 'back' to go back to the last menue");

        }

        public static void ConfirmPurchase(string item, int quant, double price, Player player)
        {

            Console.WriteLine("purchased " + quant + " " + item + " for $" + price);
            Console.WriteLine("remaining money $" + FormatDouble(player.wallet.Money));
        }

     

        public static void DisplayRecipe(int amountOfLemons, int amountOfSugarCups, int amountOfIceCubes, double pricePerCup)
        {
            Console.WriteLine("Current Recipe");            Console.WriteLine();
            Console.WriteLine("Lemons per pitcher = " + amountOfLemons);            Console.WriteLine("Sugar per pitcher = " + amountOfSugarCups);            Console.WriteLine("IceCubes per glass = " + amountOfIceCubes); // X 12 is per pitcher
            Console.WriteLine("Price per cup = $" + pricePerCup);            Console.WriteLine();
        }

        public static void DisplayRecipe(Player player)
        {
            Console.WriteLine("Current Recipe");            Console.WriteLine();
            Console.WriteLine("Lemons per pitcher = " + player.recipe.amountOfLemons);            Console.WriteLine("Sugar per pitcher = " + player.recipe.amountOfSugarCups);            Console.WriteLine("IceCubes per glass = " + player.recipe.amountOfIceCubes); // X 12 is per pitcher
            Console.WriteLine("Price per cup = $" + player.recipe.pricePerCup);            Console.WriteLine();
        }


        public static void SoldOut()
            {
            Console.WriteLine("You sold out! Not enough inventory to keep making lemonade!");
            Console.ReadLine();
        }

        public static void DisplayDayResult(int cupsSold, double profit, Day day, int currentDay)
        {
            Console.Clear();
            Console.WriteLine("DAY " + currentDay + " RESULTS:");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("Sold " + cupsSold + " cups of lemonade to " + day.crowd + " potential customers for a total of $"+FormatDouble(profit));
            Console.WriteLine();
            Console.WriteLine("Press Enter to advance to next day");
            Console.ReadLine();

        }



        /// HELPERS
        ///

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

            output = DLimiter(Math.Floor(output * 100d) / 100d, .01, 1);

            
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

        public static void DisplayTotalProfit(double gross, int days)
        {
            Console.WriteLine("Season Finished!");
            Console.WriteLine();
            Console.WriteLine("In " + days + " days you ");

            if (gross > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Profited $" + gross);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Lost $" + gross);
                Console.ResetColor();
            }
        }


        public static bool PlayAgainMenu()
        {
            string input = GetUserInput("Play again? 'yes' or 'no'");

            while (input!= "yes" && input != "no")
            {
                input = RetryGetUserInput("not a valid response type 'yes' or 'no'");
              
            }
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

    }
}
