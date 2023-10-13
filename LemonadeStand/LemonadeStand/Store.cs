using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void DisplayStorePrices()
        {
            Console.WriteLine($"Lemon: ${pricePerLemon}  SugarCube: ${pricePerSugarCube} IceCube: ${pricePerIceCube} Cup: ${pricePerCup}");
        }

        public void SellItems(Player players)
        {
            SellLemons(players);
            SellSugarCubes(players);
            SellIceCubes(players);
            SellCups(players);
        }

        public void SellLemons(Player player)
        {
            while (true)
            {
                int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons", player);
                double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
                if (player.wallet.Money >= transactionAmount)
                {
                    player.wallet.PayMoneyForItems(transactionAmount);
                    player.inventory.AddLemonsToInventory(lemonsToPurchase);
                    break;
                }
                else
                {
                    Console.WriteLine($"Not enough funds, avalable: ${Math.Round(player.wallet.Money, 2)}");
                }
            }
        }

        public void SellSugarCubes(Player player)
        {
            while (true)
            {
                int sugarToPurchase = UserInterface.GetNumberOfItems("sugar", player);
                double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
                if (player.wallet.Money >= transactionAmount)
                {
                    PerformTransaction(player.wallet, transactionAmount);
                    player.inventory.AddSugarCubesToInventory(sugarToPurchase);
                    break;
                }
                else
                {
                    Console.WriteLine($"Not enough funds, avalable: ${Math.Round(player.wallet.Money, 2)}");
                }
            }
        }

        public void SellIceCubes(Player player)
        {
            while (true)
            {
                int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes", player);
                double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
                if (player.wallet.Money >= transactionAmount)
                {
                    PerformTransaction(player.wallet, transactionAmount);
                    player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
                    break;
                }
                else
                {
                    Console.WriteLine($"Not enough funds, avalable: ${Math.Round(player.wallet.Money, 2)}");
                }
            }
        }

        public void SellCups(Player player)
        {
            while (true)
            {
                int cupsToPurchase = UserInterface.GetNumberOfItems("cups", player);
                double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
                if (player.wallet.Money >= transactionAmount)
                {
                    PerformTransaction(player.wallet, transactionAmount);
                    player.inventory.AddCupsToInventory(cupsToPurchase);
                    break;
                }
                else
                {
                    Console.WriteLine($"Not enough funds, avalable: ${Math.Round(player.wallet.Money, 2)}");
                }
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
