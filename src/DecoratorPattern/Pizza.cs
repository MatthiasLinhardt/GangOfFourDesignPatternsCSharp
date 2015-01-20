using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    public abstract class Pizza
    {
        public abstract string GetName();
        public abstract int GetPriceInCents();
    }

    public class Hawaii : Pizza
    {
        public override string GetName()
        {
            return "Pizza Hawaii";
        }
        
        public override int GetPriceInCents()
        {
            return 750;
        }
    }

    public class Tuna : Pizza
    {
        public override string GetName()
        {
            return "Pizza Thunfisch";
        }

        public override int GetPriceInCents()
        {
            return 850;
        }
    }
}
