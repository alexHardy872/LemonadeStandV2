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
            Console.WriteLine(forcast);
            Console.WriteLine();
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

        public static void DisplayQuantityMenu()
        {

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




    }
}
