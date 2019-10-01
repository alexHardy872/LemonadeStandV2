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
            
            CreateAllDays();
            
            CreatePlayer();

            currentDay = 1;

            
            for (int i = 0; i < days.Count; i++)
            {
                UserInterface.DisplayDay(currentDay);
               

                UserInterface.DisplayForcast(days[i]);

                UserInterface.SevenDayForcast(days, days[i], currentDay);
                

                GoToStore();

                player.recipe.GoToRecipe();

                RunDay();
               
            

                //total profits (money at start of day minus money at end)

                currentDay++;
            }

            // total profit from day 1;




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

            // act out day

            // pour pitcher
            // subtract from inventory (ice *12)

            // loop through customers to see if they buy

            // add money as they buy
        }



    }
}
