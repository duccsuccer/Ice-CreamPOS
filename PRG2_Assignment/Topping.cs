using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Topping
    {
        public string Toptype { get; set; }
        public Topping () { }
        public Topping(string toptype)
        {
            Toptype = toptype;
        }
        public override string ToString()
        {
            return $"Type of Toppings: {Toptype}";
        }
        
    }
}
