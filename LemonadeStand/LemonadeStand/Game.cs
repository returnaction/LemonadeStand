using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Game
    {
        int currentDay;
        int numberofPlayers;
        List<Player> players;
        List<Day> days;
        Store store;
        Player playerWinner;

        public Game()
        {
            currentDay = 1;
            players = new List<Player>();
            store = new Store();
            days = new List<Day>
            {
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day()
            };
            playerWinner = new Player();
        }

        // SRP . Only Setting number of players
        public int NumberOfPlayers()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter number of Players: 1, 2 , 3 , 4 , 5 :");

                    numberofPlayers = Convert.ToInt32(Console.ReadLine());

                    if (numberofPlayers > 0 && numberofPlayers <= 5)
                    {
                        return numberofPlayers;
                    }
                    else
                    {
                        Console.WriteLine("\nChoose beetween 1 and 5:");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nWrong input, must be an interger");
                }
            }
        }

        // SRP . Only Creating players
        public void GeneratePlayers(int numberOfPlayers)
        {
            for (int i = 1; i <= numberofPlayers; i++)
            {
                Console.WriteLine($"\nEnter a name for player {i}");
                string name = Console.ReadLine();

                if (name == "" || name == " " || name == "  ")
                {
                    players.Add(new Player());
                    players[i - 1].name = $"Player {i}";
                }
                else
                {
                    players.Add(new Player());
                    players[i - 1].name = name;
                }
            }
        }

        // SRP. Only Creating Players
        public void DisplayPlayers()
        {
            Console.WriteLine("\nList of players:");

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"Player {i + 1}: {players[i].name}");
            }
        }

        // SRP. Welcome method only
        public void Welcome()
        {
            Console.WriteLine("\nWelcome to Lemonade Stand!");
            Console.WriteLine("You have 7 days to make as much money as you can.");
            Console.WriteLine("The weather, along with your pricing, can affect your success.");
            Console.WriteLine("Can you make the big bucks");
            Console.WriteLine("Player with the biggest stack wins");
        }
        // SRP.  Day anouncment
        public void AnounceStartOftheDay()
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"\nDay {currentDay} begins!");
        }

        // SRP Changing the weather
        public void WeatherChanger()
        {
            int changeWeather = UserInterface.GenerateRandom1to9();
            if (changeWeather < 3)
            {
                //then well change it
                if (days[currentDay - 1].weather.condition == "perfect")
                {
                    days[currentDay - 1].weather.condition = "bad";
                    days[currentDay - 1].weather.temperature = 50;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];
                    days[currentDay - 1].weather.isWeatherChanged = true;
                }
                else if (days[currentDay - 1].weather.condition == "bad")
                {
                    days[currentDay - 1].weather.condition = "perfect";
                    days[currentDay - 1].weather.temperature = 80;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];
                    days[currentDay - 1].weather.isWeatherChanged = true;
                }
                else
                {
                    days[currentDay - 1].weather.condition = "perfect";
                    days[currentDay - 1].weather.temperature = 80;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];
                    days[currentDay - 1].weather.isWeatherChanged = true;
                }
            }
        }

        public void CustomerPurchase()
        {
            for (int j = 0; j < players.Count; j++)
            {
                Console.WriteLine($"\tPlayer {players[j].name} is selling...");

                for (int i = 0; i < days[currentDay - 1].customers.Count - 1; i++)
                {
                    bool result = days[currentDay - 1].customers[i].Purchase(players[j], players[j].recipe, days[currentDay - 1].weather.condition);

                    if (result == true)
                    {
                        players[j].Sell();
                    }
                    else
                    {
                        Console.WriteLine("Customer pass by......");
                    }
                }
                Console.WriteLine();
            }
        }

        public void CloseTheDay()
        {
            DisplayActualWether();
            DisplayTheResultsOfTheDay();
            AnounceEndOftheDay();
        }

        // SRP. Only Displaying weather after it was changed or not changed
        public void DisplayActualWether()
        {
            Console.WriteLine($"\nActual weather was {days[currentDay - 1].weather.condition}, Temperature: {days[currentDay - 1].weather.temperature} C");
        }
        
        // SRP 
        public void DisplayTheResultsOfTheDay()
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].CloseTheStand();
            }
        }

        // SRP only anouncing that the day  is over
        public void AnounceEndOftheDay()
        {
            Console.WriteLine($"\nDay {currentDay} is over! ");
            Console.WriteLine("_________________________________________________");
            currentDay++;
        }

        public void GameResuts()
        {
            DisplayGameResultsOfAllPlayers();
            DetermineTheWinner();
            DisplayTheWinner();
        }

        // SRP only Displaying How much all players made $
        public void DisplayGameResultsOfAllPlayers()
        {
            Console.WriteLine();

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{players[i].name} made: ${players[i].wallet.Money}");
            }
        }
        // SRP only determine the winner
        public void DetermineTheWinner()
        {
            for (int i = 1; i < players.Count; i++)
            {
                playerWinner = players[0];
                if (playerWinner.wallet.Money < players[i].wallet.Money)
                {
                    playerWinner = players[i];
                }
            }
        }

        // SRP only displaying the winner
        public void DisplayTheWinner()
        {
            Console.WriteLine($"\nThe winner is {playerWinner.name}!!!");
        }

        public void GameSimulation()
        {
            while (currentDay < 8)
            {
                AnounceStartOftheDay();

                days[currentDay - 1].weather.DisplayTemperature();

                WeatherChanger();

                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine($"\nPlayer #{i + 1}");
                    players[i].OpenTheStand();
                    store.DisplayStorePrices();
                    store.SellItems(players[i]);

                    players[i].DrinkPreperation();
                }

                CustomerPurchase();

                CloseTheDay();
            }
        }
        // SRP. Method that call other methods only
        public void RunGame()
        {
            NumberOfPlayers();
            GeneratePlayers(numberofPlayers);
            DisplayPlayers();
            Welcome();
            GameSimulation();
            GameResuts();
        }
    }
}
