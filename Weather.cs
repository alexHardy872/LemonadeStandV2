using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Weather
    {
        public string condition;
        public int temperature;
        private List<string> weatherConditions;
        public string predictedForecast;
        public int predictedTemp;
        

        public Weather()
        {
            weatherConditions = new List<string> { "Snowy", "Rainy", "Overcast", "Clear", "Sunny" };            temperature = UserInterface.RandomNumber(30, 100);            condition = weatherConditions[UserInterface.RandomNumber(0, 4)];
            PredictWeather();
            PredictTemperature();
        }




        public void PredictWeather()
        {
            int index = weatherConditions.IndexOf(condition);
            int accuracy = UserInterface.RandomNumber(0, 2);
            int error = UserInterface.RandomNumber(0, 1);

            if (index == 0)
            {
                error = 0;
            }
            else if (index == weatherConditions.Count-1)
            {
                error = 1;
            }

            if (accuracy > 0)
            {
                predictedForecast = condition;
            }
            else
            {
                if (error == 0)                {                    predictedForecast = weatherConditions[index + 1];                }                else                {                    predictedForecast = weatherConditions[index - 1];                }
            }

        }


        public void PredictTemperature()
        {
            int error = UserInterface.RandomNumber(0, 1);            if (error == 0)            {                predictedTemp = temperature - UserInterface.RandomNumber(0, 10);            }            else            {                predictedTemp = temperature + UserInterface.RandomNumber(0, 10);            }
        }



        public string SendPredictedWeather()
        {
            return  predictedTemp + " degrees and " + predictedForecast;
        }


        public string SendActualWeather()
        {
            return temperature + " degrees and " + condition;
        }




      


    }
}
