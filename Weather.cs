﻿using System;

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
            weatherConditions = new List<string> { "Snowy", "Rainy", "Overcast", "Clear", "Sunny" };
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
                if (error == 0)
            }

        }


        public void PredictTemperature()
        {
            int error = RandomNumber(0, 1);
        }



        public string SendPredictedWeather()
        {
            return  predictedTemp + " degrees and " + predictedForcast;
        }


        public string SendActualWeather()
        {
            return temperature + " degrees and " + condition;
        }




        public int RandomNumber(int min, int max)


    }
}