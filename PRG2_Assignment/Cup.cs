using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Cup : IceCream
    {
        public Cup() { }
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings)
        {

        }
        public override double CalculatePrice()
        {
            double price = 0;
            if (Scoops == 1)
            {
                price = 4;

            }
            else if (Scoops == 2)
            {
                price = 5.50;

            }
            else if (Scoops == 3)
            {
                price = 6.50;
            }
            return price + Toppings.Count;
        }
        public override string ToString()
        {
            return base.ToString() + $"Price +{CalculatePrice()}";
        }
    }
}
