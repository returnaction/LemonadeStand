using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Customer
    {
        public string name;

        public Customer()
        {
            name = "Customer";
        }

        public bool Purchase(Player player, Recipe recipe, string weather)
        {
            int number = UserInterface.GenerateRandom1to9();

            if (weather == "perfect")
            {
                if (recipe.price <= 1)
                {
                    if (number > 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                else if (recipe.price > 1 && recipe.price < 3)
                {
                    if (number > 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (number > 7)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else if (weather == "good")
            {
                if (recipe.price <= 1)
                {
                    if (number > 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (recipe.price > 1 && recipe.price < 3)
                {
                    if (number > 4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (number > 8)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else // if weather is bad
            {
                if (recipe.price <= 1)
                {
                    if (number > 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (recipe.price > 1 && recipe.price < 3)
                {
                    if (number > 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (number > 9)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
