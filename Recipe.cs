using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Recipe
    {
        public int amountOfLemons;
        public int amountOfSugarCups;
        public int amountOfIceCubes;
        public double pricePerCup;


        public Recipe()
        {
            amountOfLemons = 0;            amountOfSugarCups = 0;            amountOfIceCubes = 0;            pricePerCup = 0;
        }





        public void DisplayRecipe()        {            Console.WriteLine("Current Recipe");            Console.WriteLine();
            Console.WriteLine("Lemons per pitcher = " + amountOfLemons);            Console.WriteLine("Sugar per pitcher = " + amountOfSugarCups);            Console.WriteLine("IceCubes per glass = " + amountOfIceCubes); // X 12 is per pitcher
            Console.WriteLine("Price per cup = " + pricePerCup);            Console.WriteLine();        }


    }
}
