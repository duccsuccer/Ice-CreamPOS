using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Customer : Order
    {
        public string Name { get; set; }
        public int Memberid { get; set; }
        public DateTime Dob { get; set; }
        public Order CurrentOrder { get; set; }
        public List<Order> Orderhistory { get; set; } = new();
        
    }
}
