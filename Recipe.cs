﻿using System;

namespace LemonadeStandV2
{
    public class Recipe
    {
        public int amountOfLemons;
        public int amountOfSugarCups;
        public int amountOfIceCubes;
        public double pricePerCup;
        bool leaveRecipe;


        public Recipe()
        {
            amountOfLemons = 0;
            leaveRecipe = false;
        }





       


        public void GoToRecipe()
        {

            while (leaveRecipe != true)
            {
                UserInterface.DisplayRecipe(amountOfLemons, amountOfSugarCups, amountOfIceCubes, pricePerCup);
                
                ChangeRecipeSwitch(ChangeInput());

            }
            



        }
        public string ChangeInput()

            string input;
            {
                input = RetryGetUserInput(input+" is not a valid respone, try again!").ToLower();
            }

            return input;




    public void ChangeRecipeSwitch(string input)
    {
        switch (input)
        {
            case "lemons":
                amountOfLemons = Int32.Parse(GetUserInput("How many lemons do you want in each pitcher?"));         
                break;
            case "sugar":
                amountOfSugarCups = Int32.Parse(GetUserInput("How much sugar do you want in each pitcher?"));          
                break;
            case "ice":
                amountOfIceCubes = Int32.Parse(GetUserInput("How much Ice do you want in each cup?"));               
                break;
            case "price":
                    pricePerCup = Double.Parse(GetUserInput("What do you want to charge per cup? ($0.01 = $1.00"));
                    break;
            case "start":
                    leaveRecipe = true;
                    break;
        }


    }







        public string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public string RetryGetUserInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            return Console.ReadLine();
        }

    }
}