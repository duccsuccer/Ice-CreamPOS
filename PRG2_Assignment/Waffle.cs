    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Waffle : IceCream
    {
        public string WaffleFlavour { get; set; }
        public Waffle() { }
        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings,string waffleFlavour) : base(option, scoops, flavours, toppings)
        {
            WaffleFlavour = waffleFlavour;
        }
        public override double CalculatePrice()
        {
            double price = 0;
            if (Scoops == 1)
            {
                price = 7.00;
                if (WaffleFlavour == "Red velvet" || WaffleFlavour == "Charcoal" || WaffleFlavour == "Pandan")
                {
                    price = 10.00;
                }
            }
            else if (Scoops == 2)
            {
                price = 8.50;
                if (WaffleFlavour == "Red velvet" || WaffleFlavour == "Charcoal" || WaffleFlavour == "Pandan")
                {
                    price = 11.50;
                }
            }
            else if (Scoops == 3)
            {
                price = 9.50;
                if (WaffleFlavour == "Red velvet" || WaffleFlavour == "Charcoal" || WaffleFlavour == "Pandan")
                {
                    price = 12.50;
                }
            }
            return price + Toppings.Count;
        }
        public override string ToString()
        {
            return base.ToString() + $"Price : {CalculatePrice()}";
        }
    }
}
