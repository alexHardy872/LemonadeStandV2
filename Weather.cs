using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;

namespace LemonadeStandV2
{
    public class Weather
    {
        public string condition;
        public int temperature;
        private List<string> weatherConditions;
        public string predictedForcast;
        public int predictedTemp;
        private Random rand;

        public Weather()
        {
            weatherConditions = new List<string> { "Snowy", "Rainy", "Overcast", "Clear", "Sunny" };            temperature = RandomNumber(30, 100);            condition = weatherConditions[RandomNumber(0, 4)];
            PredictWeather();
            PredictTemperature();
        }




        public void PredictWeather()
        {
            int index = weatherConditions.IndexOf(condition);
            int accuracy = RandomNumber(0, 2);
            int error = RandomNumber(0, 1);

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
                predictedForcast = condition;
            }
            else
            {
                if (error == 0)                {                    predictedForcast = weatherConditions[index + 1];                }                else                {                    predictedForcast = weatherConditions[index - 1];                }
            }

        }


        public void PredictTemperature()
        {
            int error = RandomNumber(0, 1);            if (error == 0)            {                predictedTemp = temperature - RandomNumber(0, 10);            }            else            {                predictedTemp = temperature + RandomNumber(0, 10);            }
        }



        public string SendPredictedWeather()
        {
            return  predictedTemp + " degrees and " + predictedForcast;
        }


        public string SendActualWeather()
        {
            return temperature + " degrees and " + condition;
        }




        public int RandomNumber(int min, int max)        {            rand = new Random();            int num = rand.Next(min, max);            return num;        }


    }
}
