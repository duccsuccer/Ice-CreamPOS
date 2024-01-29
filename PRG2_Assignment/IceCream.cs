using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    abstract class IceCream
    {
        private string option;
        public string Option { get;set; }
        private int scoops;
        public int Scoops { get; set; }
        private List<Flavour> flavours;
        public List<Flavour> Flavours { get; set; } = new();
        private List<Topping> toppings;
        public List<Topping> Toppings { get; set; } = new();
        public IceCream() { }
        public IceCream(string option,int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
        }
        public virtual double CalculatePrice()
        {
            double price = 0;

            if (Option == "Cup")
            {
                if (Scoops == 1) price = 4.00;
                else if (Scoops == 2) price = 5.50;
                else if (Scoops == 3) price = 6.50;
            }
            else if (Option == "Cone")
            {
                if (Scoops == 1) price = 4.00;
                else if (Scoops == 2) price = 5.50;
                else if (Scoops == 3) price = 6.50;
            }
            else if (Option == "Waffle")
            {
                if (Scoops == 1) price = 7.00;
                else if (Scoops == 2) price = 8.50;
                else if (Scoops == 3) price = 9.50;
            }

            foreach (Flavour flavour in Flavours)
            {
                if (flavour.Premium == true)
                    price += 2.00;
            }

            price += Toppings.Count;

            return price;
        }
        public override string ToString()
        {
            string flavors = string.Join(", ", Flavours.Select(flavour => flavour.Ftype));
            string toppings = string.Join(", ", Toppings.Select(topping => topping.Toptype));

            return $"Option: {Option}, Scoops: {Scoops}, Flavours: {flavors}, Toppings: {toppings} ";
        }

    }
}
