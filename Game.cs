using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStandV2
{
    public class Game
    {
        Player player;
        List<Day> days;
        Store store;
        int currentDay;
        int gameLength;
        bool quitGame;

        public Game()
        {
            store = new Store();
            
        }


        public void StartGame()
        {
            bool playAgain;
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




                    bool start = false;
                    do
                    {
                        
                        GoToMenu();
                        if (quitGame == false)
                        {
                            start = UserInterface.GoodToStart(player);
                        }
                        
                        
                    }
                    while (start == false && quitGame == false);

                    if (quitGame == false)
                    {
                        RunDay();
                        player.inventory.iceCubes.Clear();
                        UserInterface.DisplayPostInventory(player, days[currentDay-1], days);
                        currentDay++;
                    }
                    else
                    {
                        break;
                    }
                }
                EndGame();
                playAgain = UserInterface.PlayAgainMenu();
                quitGame = false;

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

            
           
           

            bool leaveMenu = false;
            while (leaveMenu == false)
            {
                UserInterface.PlayerInfoDisplay(player, days[currentDay - 1], days);
                UserInterface.DisplayMenu();
                string selection = UserInterface.GetUserInput("Where would you like to go?");
                while (selection.ToLower() != "start" && selection.ToLower() != "store" && selection.ToLower() != "recipe" && selection.ToLower() != "quit" && selection.ToLower() != "forecast")
                {
                    selection = UserInterface.RetryGetUserInput("not a valid selection!");
                }
                switch (selection)
                {
                    case "store":
                        Console.Clear();
                        GoToStore();
                        break;
                    case "recipe":
                        Console.Clear();
                        player.recipe.GoToRecipe(player, days[currentDay-1], days);
                        break;
                    case "start":
                        Console.Clear();
                        leaveMenu = true;
                        break;
                    case "quit":
                        Console.Clear();
                        leaveMenu = true;
                        quitGame = true;
                        break;
                    case "forecast":
                        
                        UserInterface.PlayerInfoDisplay(player, days[currentDay-1], days);
                        UserInterface.SevenDayForecast(days, (currentDay -1));
                        
                        break;
                }
            }
            }

   


        public void GoToStore()
        {
            
            store.GoToTheStore(player, days[currentDay-1], days);

        }

      
        public void RunDay()
        {

            
            
            int cupsSold = 0;
            double dailyGross = 0;
            player.pitcher.cupsLeftInPitcher = 0;
            UserInterface.LiveInfoDisplay(player, days[currentDay - 1], days, dailyGross);


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
                        player.wallet.Money += player.recipe.pricePerCup;
                        UserInterface.ClearSpace( player, days[currentDay-1], days, dailyGross);
                        UserInterface.DisplayPurchase(dailyGross, customer.name);
                        cupsSold += 1;
                    }
                }
                else
                {
                    
                    UserInterface.ClearSpace( player, days[currentDay-1], days, dailyGross);
                    UserInterface.DisplayPass(customer.name);
                }
            }

            player.pitcher.cupsLeftInPitcher = 0;
            UserInterface.DisplayDayResult(cupsSold, dailyGross, days[currentDay-1], currentDay, player);
            

        }


        public void EndGame()
        {
            double totalProfit = player.wallet.Money - 20;
            UserInterface.DisplayTotalProfit(totalProfit, days.Count);
        }
    }
}
