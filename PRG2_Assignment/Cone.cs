using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Cone : IceCream
    {
        public bool Dipped { get; set; }

        public Cone() { }
        public Cone(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours, toppings)
        {
            Dipped = dipped;
        }
        public override double CalculatePrice()
        {
            double baseprice = base.CalculatePrice();
            if (Dipped == true)
            {
                baseprice += 2.00;
            }

            return baseprice;
        }           
        public override string ToString()
        {
            return base.ToString() + $" Price{CalculatePrice()}";
        }
    }
}
