using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public static class UserInterface
    {
        






        public static void DisplayStoreMenu()
        {

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







    }
}
