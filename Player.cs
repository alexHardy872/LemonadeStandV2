using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Player
    {
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;
        public double buisnessProfits;



        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            pitcher = new Pitcher();
        }

        public bool PourCup()
        {
            if (inventory.cups.Count >= 1 && inventory.iceCubes.Count >= recipe.amountOfIceCubes)
            {
                inventory.cups.RemoveAt(0);
                inventory.iceCubes.RemoveRange(0, recipe.amountOfIceCubes);
                pitcher.cupsLeftInPitcher -= 1;
                return true;
            }
            else
            {
                return false; // SOLD OUT
            }
        }

        public bool PourPitcher()
        {
            if (inventory.lemons.Count >= recipe.amountOfLemons && inventory.sugarCups.Count >= recipe.amountOfSugarCups) 
            {
                inventory.lemons.RemoveRange(0, recipe.amountOfLemons);
                inventory.sugarCups.RemoveRange(0, recipe.amountOfSugarCups);
                pitcher.cupsLeftInPitcher = 12;

                return true;
            }
            else
            {
                return false; // SOLD OUT
            }

            
        }






    }
}
