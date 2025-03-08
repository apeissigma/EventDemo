/*
 * Stock Prices (Event Handlers)
 * Ashani Li Peissigma
 * 3/8/2025
 * Modified and extended from example code at http://www.albahari.com/nutshell/E9-CH04.aspx
 */

using System;

namespace EventDemo
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Programming II Stock Prices (Event Handlers) by Ashani";
            Exchange exchange = new Exchange();
            exchange.Open();
        }
    }
}
