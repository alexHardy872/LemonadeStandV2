﻿using System;

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
            Console.WriteLine("Current Recipe");
            Console.WriteLine("Lemons per pitcher = " + amountOfLemons);
            Console.WriteLine("Price per cup = $" + pricePerCup);
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