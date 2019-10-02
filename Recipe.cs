using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

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
            amountOfLemons = 0;            amountOfSugarCups = 0;            amountOfIceCubes = 0;            pricePerCup = 0.01;
            leaveRecipe = false;
        }





       


        public void GoToRecipe()
        {
            leaveRecipe = false;

            while (leaveRecipe != true)
            {
                UserInterface.DisplayRecipe(amountOfLemons, amountOfSugarCups, amountOfIceCubes, pricePerCup);
                
                ChangeRecipeSwitch(ChangeInput());

            }
            



        }
        public string ChangeInput()        {

            string input;                                                       input = UserInterface.GetUserInput("To mofify the recipe, type 'lemons', 'sugar', 'ice', 'price', or when you are ready press 'start'").ToLower();                                while(input != "price" && input != "lemons" && input != "sugar" && input != "ice" && input != "start")
            {
                input = UserInterface.RetryGetUserInput(input+" is not a valid respone, try again!").ToLower();
            }

            return input;                    }




    public void ChangeRecipeSwitch(string input)
    {
        switch (input)
        {
            case "lemons":
                amountOfLemons = Int32.Parse(UserInterface.GetUserInput("How many lemons do you want in each pitcher?"));         
                break;
            case "sugar":
                amountOfSugarCups = Int32.Parse(UserInterface.GetUserInput("How much sugar do you want in each pitcher?"));          
                break;
            case "ice":
                amountOfIceCubes = Int32.Parse(UserInterface.GetUserInput("How much Ice do you want in each cup?"));               
                break;
            case "price":
                    pricePerCup = Double.Parse(UserInterface.GetUserInput("What do you want to charge per cup? ($0.01 = $1.00"));
                    break;
            case "start":
                    leaveRecipe = true;
                    break;
        }


    }







       

    }
}
