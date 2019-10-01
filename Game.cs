using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

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
            Welcome();
            SetGameLength();
            // Create Days,
            CreateAllDays();
            // Create Player,
            CreatePlayer();

            // LOOP THROUGH DAYS LIST
            for (int i = 0; i < days.Count; i++)
            {
                Console.WriteLine("Day " + currentDay + 1);

                DisplayMoney();
                DisplayInventory();

                // send to store

                // send to recipe

                // act out day

                currentDay++;
            }




        }

        public void CreatePlayer()
        {
            player = new Player();
        }

        public void SetGameLength()
        {
            gameLength = Int32.Parse(GetUserInput("How many days would you like the game to last?"));

        }

        public void NewDay(int dayNum)        {            Day day = new Day(dayNum);
            days.Add(day);        }        public void CreateAllDays()        {            days = new List<Day> { };            for (int i = 1; i <= gameLength; i++)            {                NewDay(i);
            }        }



        public string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        


        public void DisplayMoney()
        {
            double money = player.wallet.Money;
            Console.WriteLine("Current funds = $" + money);
        }

        public void DisplayInventory()
        {
            player.inventory.DisplayInventory();
        }

        public void Welcome()
        {            Console.WriteLine("Welcome to Lemonade Stand! Press ENTER to begin!");                 Console.ReadLine();            Console.Clear();
        }

        
    }
}
