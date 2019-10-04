using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Store
    {
        
        
        private bool leaveStore;




        public Store()
        {
            
            leaveStore = false;
        }

        public void GoToTheStore(Player player, Day day, List<Day> days)
        {

            do
            {
                UserInterface.PlayerInfoDisplay(player, day, days);
 
                UserInterface.DisplayStoreMenu();
                MenuSelection(player, day , days);

            }
            while (leaveStore == false);
           

        }


        public void MenuSelection(Player player, Day day, List<Day> days)
        {
            string input;

            input = Console.ReadLine().ToLower();

            while (input != "cups" && input != "lemons" && input != "sugar" && input != "ice" && input != "done")
            {
                input = UserInterface.RetryGetUserInput(input + " is not a valid choice, please try again");
            }

            switch (input)
            {
                case "cups":
                    QuantityMenu("cups", 25, 50, 100, 2.00, 3.50, 4.25, player, day, days);
                    break;
                case "lemons":
                    QuantityMenu("lemons", 10, 45, 75, 2.00, 3.00, 4.00, player, day, days);
                    break;
                case "sugar":
                    QuantityMenu("sugar", 10, 45, 75, 1.50, 4.50, 5.75, player, day, days);
                    break;
                case "ice":
                    QuantityMenu("ice", 100, 250, 500, 1.75, 3.25, 5.25, player, day, days);
                    break;
                case "done":
                    leaveStore = true;
                    Console.Clear();
                    break;

            }

        }

        public void QuantityMenu(string item, int quant1, int quant2, int quant3, double price1, double price2, double price3, Player player, Day day, List<Day> days)        {            string choice;            UserInterface.DisplayStoreQuantities(item, quant1, quant2, quant3, price1, price2, price3);            choice = Console.ReadLine();            while (choice != "1" && choice != "2" && choice != "3" && choice != "back")            {                choice = UserInterface.RetryGetUserInput("not a valid entry, please type '1','2','3', or 'back'");            }            switch (choice)            {                case "1":                    PurchaseItems(item, quant1, price1, player, day, days);                    break;                case "2":                    PurchaseItems(item, quant2, price2, player, day, days);                    break;                case "3":                    PurchaseItems(item, quant3, price3, player, day, days);                    break;                case "back":                    GoToTheStore(player, day, days);                    break;            }        }


        public void PurchaseItems(string item, int quant, double price, Player player , Day day, List<Day> days)        {            bool didBuy = player.wallet.CheckWallet(price);            if (didBuy == true)            {                UserInterface.ConfirmPurchase(item, quant, price, player);                player.inventory.AddItemsToInventory(quant, item);
                UserInterface.PlayerInfoDisplay(player, day, days);                GoToTheStore(player, day, days);            }            else            {                UserInterface.NotEnoughMoney();                            }        }








   

    }
}
