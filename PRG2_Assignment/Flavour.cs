using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Flavour
    {
        public string Ftype { get; set; }
        public bool Premium { get; set; }
        public int Qty { get; set; }
        public Flavour() { }    
        public Flavour(string ftype, bool premium, int qty)
        {
            Ftype = ftype;
            Premium = premium;
            Qty = qty;
        }
        public override string ToString()
        {
            return $"Flavour Type: {Ftype}, Premium: {Premium}, Quantity: {Qty}";
        }
    }
}
