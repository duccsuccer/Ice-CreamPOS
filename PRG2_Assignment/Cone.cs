﻿using System;
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
            double price = 0;
            if (Scoops == 1) 
            {
                price = 4;
                if (Dipped == true)
                {
                    price += 2.0;
                }
            }
            else if (Scoops == 2) 
            {
                price = 5.50;
                if (Dipped == true)
                {
                    price += 2.0;
                }
            }
            else if(Scoops == 3)
            {
                price = 6.50;
                if (Dipped == true)
                {
                    price += 2.0;
                }
            }
            return price + Toppings.Count;
        }           
        public override string ToString()
        {
            return base.ToString() + $" Price{CalculatePrice()}";
        }
    }
}
