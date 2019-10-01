﻿using System;

namespace LemonadeStandV2
{
    public class Store
    {
        Player player;
        private bool leaveStore;




        public Store(Player playerIn)
        {
            player = playerIn;
            leaveStore = false;
        }

        public void GoToTheStore()
        {

            do
            {
                DisplayStoreMenu();
                MenuSelection();

            }
            while (leaveStore == false);
           

        }

        public void DisplayStoreMenu()
        {

            Console.WriteLine("You have $" + player.wallet.Money);
            Console.WriteLine();
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine();
            Console.WriteLine("Cups? type 'cups'");
            Console.WriteLine("Lemons? type 'lemons'");
            Console.WriteLine("Sugar? type 'sugar'");
            Console.WriteLine("Ice Cubes? type 'ice'");
            Console.WriteLine("Advance to recipe? type 'done'");
            Console.WriteLine();

        }

        public void MenuSelection()
        {
            string input;

            input = Console.ReadLine();

            while (input != "cups" && input != "lemons" && input != "sugar" && input != "ice" && input != "done")
            {
                input = RetryGetUserInput(input + " is not a valid choice, please try again");
            }

            switch (input)
            {
                case "cups":
                    QuantityMenu("cups", 25, 50, 100, 2.00, 3.50, 4.25);
                    break;
                case "lemons":
                    QuantityMenu("lemons", 10, 45, 75, 2.00, 3.00, 4.00);
                    break;
                case "sugar":
                    QuantityMenu("sugar", 10, 45, 75, 1.50, 4.50, 5.75);
                    break;
                case "ice":
                    QuantityMenu("ice", 100, 250, 500, 1.75, 3.25, 5.25);
                    break;
                case "done":
                    leaveStore = true;
                    break;

            }

        }

        public void QuantityMenu(string item, int quant1, int quant2, int quant3, double price1, double price2, double price3)


        public void PurchaseItems(string item, int quant, double price)

                Console.WriteLine("remaining money $" + player.wallet.Money);
                








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