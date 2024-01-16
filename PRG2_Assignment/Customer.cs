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
        public PointCard Rewards { get; set; }
        public Customer() { }
        public Customer(string name, int memberid,DateTime dob)
        {
            Name = name;
            Memberid = memberid;
            Dob = dob;
        }
        public Order MakeOrder()
        {
            Order order = new Order();
            return order;
        }
        public bool IsBirthday()
        {
            if (Dob != DateTime.Now)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Member ID: {Memberid}, Date Of Birth: {Dob}";
        }

    }
}
