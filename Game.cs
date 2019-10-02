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

                    UserInterface.DisplayDay(currentDay);
                    UserInterface.DisplayForcast(days[i]);
                    UserInterface.SevenDayForcast(days, days[i], currentDay);
                    UserInterface.DisplayInventory(player);
                    GoToStore();
                    player.recipe.GoToRecipe();
                    RunDay();  
                    player.inventory.iceCubes.RemoveRange(0, player.inventory.iceCubes.Count);
                    UserInterface.DisplayPostInventory(player);
                    currentDay++;
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
            gameLength = UserInterface.Limiter(Int32.Parse(UserInterface.GetUserInput("How many days would you like the game to last? (Max 30)")),1,30); // validate num?
            Console.Clear();
        }

        public void NewDay(int dayNum)        {            Day day = new Day(dayNum);
            days.Add(day);        }        public void CreateAllDays()        {            days = new List<Day> { };            for (int i = 1; i <= gameLength; i++)            {                NewDay(i);
            }        }




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
            bool soldOut = false;

            foreach (Customer customer in days[currentDay-1].customers)
                {

                if (player.pitcher.cupsLeftInPitcher == 0)
                {
                    bool successfulPour = player.PourPitcher();
                    if (successfulPour == false)
                    {
                        soldOut = true;
                        UserInterface.SoldOut();
                        break;
                        
                    }

                }

                bool didBuy = customer.CustomerApproachesStand(player.recipe.pricePerCup, player.recipe.amountOfIceCubes, player.recipe.amountOfLemons, player.recipe.amountOfSugarCups);
                if (didBuy == true)
                {

                    dailyGross += player.recipe.pricePerCup;
                    player.pitcher.cupsLeftInPitcher -= 1;
                    cupsSold += 1;

                
                } 

            }

            player.wallet.Money += dailyGross;
            UserInterface.DisplayDayResult(cupsSold, dailyGross, days[currentDay-1], currentDay);
            Thread.Sleep(2000);

        }


        public void EndGame()
        {
            double totalProfit = player.wallet.Money - 20;
            UserInterface.DisplayTotalProfit(totalProfit, days.Count);
        }
    }
}
