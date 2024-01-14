using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime Timereceived { get; set; }
        public DateTime? Timefufilled {  get; set; }
        public List<IceCream> IceCreamList { get; set; } = new();
        public Order() { }
        public Order(int id, DateTime timereceived)
        {
            Id = id;
            Timereceived = timereceived;
        }
        public void ModifyIceCream(int id)
        {
            if (id == Id)
            {
                Console.Write("Option: ");
                string option = Console.ReadLine();
                Console.Write("Number of scoops");
                int scoops = Convert.ToInt32(Console.ReadLine());
                Console.Write("Flavour: ");
                string flavour = Console.ReadLine();
                
            }
        }
        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }
        public void DeleteIceCream(IceCream iceCream)
        {
            IceCreamList.Remove(iceCream);
        }
        public double CalculateTotal()
        {
            double total = 0;
            foreach (IceCream iceCream in IceCreamList)
            {
                total += iceCream.CalculatePrice();
            }
            return total;
        }

    }
}
