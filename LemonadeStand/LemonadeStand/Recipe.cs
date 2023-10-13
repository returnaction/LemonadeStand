using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Recipe
    {
        // member variables (HAS A)
        public int numberOfLemons;
        public int numberOfSugarCubes;
        public int numberOfIceCubes;
        public double price;
        public string name;

        // constructor (SPAWNER)
        public Recipe()
        {
            numberOfLemons = 2;
            numberOfSugarCubes = 4;
            numberOfIceCubes = 10;
            price = 1;
            name = "Regular Lemonade";
        }

        //Member Methods (CAN DO)
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nYour recipe {name} price ${price} and consists " +
                 $"of:\n{numberOfLemons} lemons per pitcher\n{numberOfSugarCubes} " +
                 $"sugar cubes per pitcher\n{numberOfIceCubes} ice cubes per pitcher");
        }

        public void ChangeRecipe()
        {
            string answer = "";
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;
            while (true)
            {
                Console.WriteLine("\nYou'd you like to change your recipe? Y/N");
                answer = Console.ReadLine();
                if (answer == "Y")
                {
                    Console.WriteLine("Enter a name:");
                    name = Console.ReadLine();
                    if (name == "" || name == " ")
                    {
                        name = "Secret Drink";
                    }

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter number of Lemons: (or 0 to cancel)");
                            numberOfLemons = Convert.ToInt32(Console.ReadLine());

                            if (numberOfLemons >= 0)
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter number of Sugar Cubes: (or 0 to cancel)");
                            numberOfSugarCubes = Convert.ToInt32(Console.ReadLine());

                            if (numberOfSugarCubes >= 0)
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter number of Ice Cubes: (or 0 to cancel)");
                            numberOfIceCubes = Convert.ToInt32(Console.ReadLine());

                            if (numberOfIceCubes >= 0)
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter a price:");
                            price = Convert.ToInt32(Console.ReadLine());

                            if (price > 0)
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    Console.WriteLine("\nSuccessfuly saved");
                    DisplayRecipe();

                    break;
                }
                else if (answer == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
