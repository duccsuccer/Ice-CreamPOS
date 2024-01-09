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
        public abstract double CalculatePrice();
        public override string ToString()
        {
            return $"Option : {Option}, Scoops: {Scoops}, Flavours: {Flavours}, Toppings: {Toppings}";
        }

    }
}
