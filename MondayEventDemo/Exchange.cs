using System;
using System.Collections.Generic;
using System.Text;

namespace MondayEventDemo
{
    class Exchange
    {
        List<Stock> Stocks = new List<Stock>()
        {
            new Stock("HCKR"),
            new Stock("PROG"),
            new Stock("c0de"),
            new Stock("CODE"),
            new Stock("BYTE")
        };
        public void Open()
        {
            SetStockPrices();
            PrintAllStockPrices();
            Run();
        }
        private void Menu()
        {
            Console.WriteLine("Press x to exit, any other key to check prices again.");
            string input = Console.ReadLine();
            if (input.ToLower() != "x")
            {
                Run();
            }

        }
        private void Run()
        {
            //call setstockprices on all stocks in the list
            foreach (Stock s in Stocks)
            {
                CheckStockPrice(s);
            }
            Menu();

        }
        private void SetStockPrices()
        {
            foreach (Stock s in Stocks)
            {
                // Register with the PriceChanged event
                s.PriceChanged += s.stock_PriceChanged;
                s.Price = Utility.RandomNumber.Next(20, 30);
            }
        }

        private void CheckStockPrice(Stock s)
        {
            s.Price = s.Price + Utility.RandomNumber.Next(-10, 10);
        }

        private void PrintAllStockPrices()
        {
            foreach (Stock s in Stocks)
            {
                Console.WriteLine($"The price of {s.Symbol} is {s.Price}");
            }
        }

    }
}
