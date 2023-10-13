using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Weather
    {
        public string condition;
        public int temperature;
        public List<string> weatherConditions;
        public string predictedForecast;
        public bool isWeatherChanged = false;

        public Weather()
        {
            weatherConditions = new List<string>
            {
                "Hot. Sunny. Clear Sky",
                "Warm. Sunny. Cloudy",
                "Cold. No sun. Cloudy"
            };
            GenerateTemperature();
        }

        // SRP . Only Generating Weather
        public void GenerateTemperature()
        {
            int number = UserInterface.GenerateRandom1to9();
            switch (number)
            {
                case 1:
                case 2:
                case 3:
                    temperature = 50;
                    predictedForecast = weatherConditions[2];
                    condition = "bad";
                    break;

                case 4:
                case 5:
                case 6:
                    temperature = 70;
                    predictedForecast = weatherConditions[1];
                    condition = "good";
                    break;

                case 7:
                case 8:
                case 9:
                    temperature = 80;
                    predictedForecast = weatherConditions[0];
                    condition = "perfect";
                    break;
            }
        }

        // SRP . Only DisplayingTemperature
        public void DisplayTemperature()
        {
            Console.WriteLine($"\nToday's forecast prediction: {predictedForecast}");
        }
    }
}
