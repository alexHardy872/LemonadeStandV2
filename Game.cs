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
            UserInterface.Welcome();
            SetGameLength();
            // Create Days,
            CreateAllDays();
            // Create Player,
            CreatePlayer();

            currentDay = 1;

            // LOOP THROUGH DAYS LIST
            for (int i = 0; i < days.Count; i++)
            {
                UserInterface.DisplayDay(currentDay);
               

                UserInterface.DisplayForcast(days[i]);
                

                

                GoToStore();

                player.recipe.GoToRecipe();
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
            gameLength = Int32.Parse(GetUserInput("How many days would you like the game to last?")); // validate num?
            Console.Clear();
        }

        public void NewDay(int dayNum)        {            Day day = new Day(dayNum);
            days.Add(day);        }        public void CreateAllDays()        {            days = new List<Day> { };            for (int i = 1; i <= gameLength; i++)            {                NewDay(i);
            }        }



        public string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        


      

   
        

        public void GoToStore()
        {
            Store store = new Store(player);
            store.GoToTheStore();

        }

      

       

        
    }
}
