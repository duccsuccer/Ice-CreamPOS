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
            double baseprice = base.CalculatePrice();
            return baseprice;
        }
        public override string ToString()
        {
            return base.ToString() + $"Price +{CalculatePrice()}";
        }
    
    }
}
