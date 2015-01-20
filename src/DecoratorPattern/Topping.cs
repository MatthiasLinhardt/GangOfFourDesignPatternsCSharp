using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    public abstract class Topping : Pizza
    {
        protected Pizza pizza;

        protected Topping(Pizza pizza)
        {
            this.pizza = pizza;
        }
    }

    public class ExtraCheese : Topping
    {
        public ExtraCheese(Pizza pizza) : base(pizza)
        {
        }

        public override string GetName()
        {
            return pizza.GetName() + ", extra Käse";
        }

        public override int GetPriceInCents()
        {
            return pizza.GetPriceInCents() + 100;
        }
    }

    public class ExtraOnions : Topping
    {
        public ExtraOnions(Pizza pizza) : base(pizza)
        {
        }

        public override string GetName()
        {
            return pizza.GetName() + ", extra Zwiebeln";
        }

        public override int GetPriceInCents()
        {
            return pizza.GetPriceInCents() + 150;
        }
    }

    public class DiscountVoucher : Topping
    {
        private readonly int discountInEuros;

        public DiscountVoucher(Pizza pizza, int discountInEuros) : base(pizza)
        {
            this.discountInEuros = discountInEuros;
        }

        public override string GetName()
        {
            return pizza.GetName() + " (mit " + discountInEuros + "Euro-Rabattgutschein)";
        }

        public override int GetPriceInCents()
        {
            return pizza.GetPriceInCents() - (discountInEuros * 100);
        }
    }
}
