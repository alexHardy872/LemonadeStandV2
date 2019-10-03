using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStandV2
{
    public class Game
    {
        Player player;
        List<Day> days;
        int currentDay;
        int gameLength;
        bool quitGame;

        public Game()
        {
            
            
        }


        public void StartGame()
        {
            bool playAgain = false;
            do
            {
                UserInterface.Welcome();

                SetGameLength();
                CreateAllDays();
                CreatePlayer();
                currentDay = 1;


                for (int i = 0; i < days.Count; i++)
                {
                    Console.Clear();

                    UserInterface.DisplayDay(currentDay, days);
                    //UserInterface.DisplayForcast(days[i]);
                    //UserInterface.SevenDayForcast(days, days[i], currentDay);
                    //UserInterface.DisplayInventory(player);

                    bool start;
                    do
                    {
                        GoToMenu();
                        start = GoodToStart();
                    }
                    while (start == false);

                    if (quitGame == false)
                    {

                        RunDay();
                        player.inventory.iceCubes.RemoveRange(0, player.inventory.iceCubes.Count);
                        UserInterface.DisplayPostInventory(player);
                        currentDay++;
                    }

                   
                }
                EndGame();
                playAgain = UserInterface.PlayAgainMenu();

            } while (playAgain == true);

            Environment.Exit(0);
        }

        public void CreatePlayer()
        {
            player = new Player();
        }

        public void SetGameLength()
        {
            gameLength = UserInterface.Limiter(UserInterface.IntGetUserInput("How many days would you like the game to last? (Max 30)"),1,30); // validate num?
            Console.Clear();
        }

        public void NewDay(int dayNum)        {            Day day = new Day(dayNum);
            days.Add(day);        }        public void CreateAllDays()        {            days = new List<Day> { };            for (int i = 1; i <= gameLength; i++)            {                NewDay(i);
            }        }

        public void GoToMenu()
        {

            
            UserInterface.DisplayForcast(days[currentDay-1]);
            UserInterface.DisplayInventory(player);
            UserInterface.DisplayRecipe(player);

            bool leaveMenu = false;
            while (leaveMenu == false)
            {
                UserInterface.DisplayMenu();
                string selection = UserInterface.GetUserInput("Where would you like to go?");
                while (selection.ToLower() != "start" && selection.ToLower() != "store" && selection.ToLower() != "recipe" && selection.ToLower() != "quit" && selection.ToLower() != "forcast")
                {
                    selection = UserInterface.RetryGetUserInput("not a valid selection!");
                }
                switch (selection)
                {
                    case "store":
                        GoToStore();
                        break;
                    case "recipe":
                        player.recipe.GoToRecipe();
                        break;
                    case "start":
                        leaveMenu = true;
                        break;
                    case "quit":
                        leaveMenu = true;
                        quitGame = true;
                        break;
                    case "forcast":
                        UserInterface.SevenDayForcast(days, currentDay - 1);
                        break;
                }
            }
            }

        public bool GoodToStart()
        {
            if (player.inventory.cups.Count == 0)
            {
                UserInterface.Error("WOAH! you have no cups in your inventory! You cant sell ANY lemonade without cups! Check your inventory and go back to the store!");
                return false;
            }
            if (player.recipe.amountOfLemons == 0 || player.recipe.amountOfSugarCups == 0 || player.recipe.amountOfIceCubes == 0)
            {
                
                string sure = UserInterface.YesOrNo(UserInterface.RetryGetUserInput("One or more items in your recipe have a quantity of ZERO, proceed 'yes' or 'no'?"));
                if (sure == "yes")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (player.inventory.lemons.Count < player.recipe.amountOfLemons || player.inventory.sugarCups.Count < player.recipe.amountOfSugarCups || player.inventory.iceCubes.Count < player.recipe.amountOfIceCubes)
            {
                UserInterface.Error("You have insufficient inventory to use your current recipee! change the recipe or go back to the store!");
                return false;
            }


            return true;
        }


        public void GoToStore()
        {
            Store store = new Store(player);
            store.GoToTheStore();

        }

      
        public void RunDay()
        {

            UserInterface.DisplayWeather(days[currentDay - 1]);

            int cupsSold = 0;
            double dailyGross = 0;
            player.pitcher.cupsLeftInPitcher = 0;
            

            foreach (Customer customer in days[currentDay-1].customers)
                {
                if (player.pitcher.cupsLeftInPitcher == 0)
                {
                    bool successfulPour = player.PourPitcher();
                    if (successfulPour == false)
                    {
                        UserInterface.SoldOut();
                        break;     
                    }
                }

                bool didBuy = customer.CustomerApproachesStand(player.recipe.pricePerCup, player.recipe.amountOfIceCubes, player.recipe.amountOfLemons, player.recipe.amountOfSugarCups);
                if (didBuy == true)
                {
                    bool successfulPour = player.PourCup();
                    if (successfulPour == false)
                    {
                        UserInterface.SoldOut();
                        break;
                    }
                    else
                    {

                        dailyGross += player.recipe.pricePerCup;
                        cupsSold += 1;
                    }
                } 
            }

            player.pitcher.cupsLeftInPitcher = 0;
            player.wallet.Money += dailyGross;
            UserInterface.DisplayDayResult(cupsSold, dailyGross, days[currentDay-1], currentDay);
            

        }


        public void EndGame()
        {
            double totalProfit = player.wallet.Money - 20;
            UserInterface.DisplayTotalProfit(totalProfit, days.Count);
        }
    }
}
