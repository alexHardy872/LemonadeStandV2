using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Inventory
    {

        public List<Item> lemons;
        public List<Item> iceCubes;
        public List<Item> cups;
        public List<Item> sugarCups;





        public Inventory()
        {
            lemons = new List<Item> { };
            iceCubes = new List<Item> { };            sugarCups = new List<Item> { };            cups = new List<Item> { };
        }



        public void AddItemsToInventory(int quantity, string item)        {            switch (item)            {                case "cups":                    for (int i = 0; i < quantity; i++)                    {                        Cup cup = new Cup();                        cups.Add(cup);                    }                    break;                case "lemons":                    for (int i = 0; i < quantity; i++)                    {                        Lemon lemon = new Lemon();                        lemons.Add(lemon);                    }                    break;                case "sugar":                    for (int i = 0; i < quantity; i++)                    {                        SugarCup sug = new SugarCup();                        sugarCups.Add(sug);                    }                    break;                case "ice":                    for (int i = 0; i < quantity; i++)                    {                        IceCube ice = new IceCube();                        iceCubes.Add(ice);                    }                    break;            }
        }



            public void DisplayInventory()
        { 
        Console.WriteLine(" Inventory");            Console.WriteLine();            Console.WriteLine(cups.Count + " Cups");            Console.WriteLine(lemons.Count + " Lemons");            Console.WriteLine(sugarCups.Count + " Cups of sugar");            Console.WriteLine(iceCubes.Count + " IceCubes");
        }



}
}
