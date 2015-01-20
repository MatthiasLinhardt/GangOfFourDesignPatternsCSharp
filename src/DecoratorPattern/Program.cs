using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderedPizzas = new List<Pizza>()
            {
                new Hawaii(), 
                new Tuna(), 
                new ExtraOnions(new Tuna()), 
                new ExtraCheese(new Hawaii()), 
                new ExtraCheese(new ExtraCheese(new ExtraOnions(new Tuna()))),
                new DiscountVoucher(new Tuna(), 5)
            };

            foreach (Pizza pizza in orderedPizzas)
            {
                Console.WriteLine(pizza.GetName() 
                                  + " kostet " 
                                  + pizza.GetPriceInCents() / 100 
                                  + "," 
                                  + string.Format("{0:00}", pizza.GetPriceInCents() % 100) 
                                  + " Euro.");
            }

            Console.ReadLine();
        }
    }
}
