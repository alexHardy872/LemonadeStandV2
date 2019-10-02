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

 

        public bool PourPitcher()
        {
            if (inventory.lemons.Count >= recipe.amountOfLemons && inventory.sugarCups.Count >= recipe.amountOfSugarCups && inventory.cups.Count >= 12 && inventory.iceCubes.Count >= recipe.amountOfIceCubes * 12)
            {
                inventory.lemons.RemoveRange(0, recipe.amountOfLemons);
                inventory.sugarCups.RemoveRange(0, recipe.amountOfSugarCups);
                inventory.cups.RemoveRange(0, 12);
                inventory.iceCubes.RemoveRange(0, (recipe.amountOfIceCubes * 12));
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
