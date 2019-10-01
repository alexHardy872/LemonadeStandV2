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

        /*

        public void SubtractPitcherFromInventory()
        {

            // in one pitcher
            int lemons = recipe.amountOfLemons;
            int sugarCups = recipe.amountOfSugarCups;
            int iceCubes = recipe.amountOfIceCubes * 12;
            int cups = recipe.amountOfSugarCups * 12;

            inventory.lemons.


                // for amount of lemons ; list.RemoveAt(o);
                // if amount not enough (list length) SOLD OUT!


        } */


    }
}
