using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public static class UserInterface
    {


        public static void Welcome()
        {            Console.WriteLine("Welcome to Lemonade Stand! Press ENTER to begin!");
            Console.ReadLine();            Console.Clear();
        }

        public static void DisplayDay(int currentDay)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Day " + currentDay);
            Console.ResetColor();

        }

        public static void DisplayMoney(Player player)
        {
            Console.WriteLine("You have $" + player.wallet.Money);
        }

        public static void DisplayForcast(Day dayIn)
        {
            string forcast = dayIn.weather.SendPredictedWeather();
            Console.WriteLine("Today's forcast is "+forcast);
            
        }

        public static void SevenDayForcast(List<Day> days, Day day, int currentDay)
        {
            int daysLeft = days.Count - currentDay;
            int daysAhead = Limiter(daysLeft, 0, 8);

            if (daysAhead > 1)
            {           
                for (int i = currentDay + 1; i < daysAhead; i++)
                {
                    string forcast = days[i].weather.SendPredictedWeather();
                    Console.WriteLine("Day " + i + " forcast " + forcast);           
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



        public static void DisplayStoreMenu()
        {

            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine();
            Console.WriteLine("Cups? type 'cups'");
            Console.WriteLine("Lemons? type 'lemons'");
            Console.WriteLine("Sugar? type 'sugar'");
            Console.WriteLine("Ice Cubes? type 'ice'");
            Console.WriteLine("Advance to recipe? type 'done'");
            Console.WriteLine();

        }

        public static void DisplayStoreQuantities(string item, int quant1, int quant2, int quant3, double price1, double price2, double price3)
        {
            Console.WriteLine("What quantity of " + item + " do you want to buy? (enter the number");            Console.WriteLine("Option '1' ( " + quant1 + " for $" + price1);            Console.WriteLine("Option '2' ( " + quant2 + " for $" + price2);            Console.WriteLine("Option '3' ( " + quant3 + " for $" + price3);            Console.WriteLine("or type 'back' to go back to the last menue");

        }

        public static void ConfirmPurchase(string item, int quant, double price, Player player)
        {

            Console.WriteLine("purchased " + quant + " " + item + " for $" + price);
            Console.WriteLine("remaining money $" + player.wallet.Money);
        }

        public static void DisplayRecipeMenu()
        {

        }

        public static void DisplayRecipe(int amountOfLemons, int amountOfSugarCups, int amountOfIceCubes, double pricePerCup)
        {
            Console.WriteLine("Current Recipe");            Console.WriteLine();
            Console.WriteLine("Lemons per pitcher = " + amountOfLemons);            Console.WriteLine("Sugar per pitcher = " + amountOfSugarCups);            Console.WriteLine("IceCubes per glass = " + amountOfIceCubes); // X 12 is per pitcher
            Console.WriteLine("Price per cup = $" + pricePerCup);            Console.WriteLine();
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

        public static bool ValidateInt(string input)
        {
            // TRY PARSE
            return false;

            return true;
        }

        public static bool ValidateDouble(string input)
        {
            // TRY PARSE
            return false;

            return true;
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


    }
}
