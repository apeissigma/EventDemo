using System;
using System.Collections.Generic;
using System.Text;

namespace MondayEventDemo
{
    class Stock
    {
        string symbol;
        decimal price;

        public Stock(string symbol) { this.symbol = symbol; }

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }

        public string Symbol { get => symbol; set => symbol = value; }

        public void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if (e.LastPrice != e.NewPrice)
                Console.WriteLine($"{Symbol} price has changed. Previous price was {e.LastPrice}, new price is {e.NewPrice}. The difference is {e.LastPrice - e.NewPrice}.");
        }

        public class PriceChangedEventArgs : EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;

            public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
            {
                LastPrice = lastPrice; NewPrice = newPrice;
            }
        }

    }
}
