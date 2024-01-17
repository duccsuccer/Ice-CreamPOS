using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
{
    internal class Order : Customer
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
            //Seeing which customer modifying their order
            Order currentOrder = selectedCustomer.CurrentOrder;
            //listing all ice cream in that order
            Console.WriteLine($"Ice Creams in Order (Order ID: {currentOrder.Id}):");
            int i = 1;
            foreach (IceCream icecreams in currentOrder.IceCreamList)
            {

                Console.WriteLine($"[{i}] {icecreams}");
                i++;
            }

            //PROMPTING TIMEE!!!!
            Console.WriteLine("Choose an action:");
            Console.WriteLine("[1] Modify an existing ice cream");
            Console.WriteLine("[2] Add a new ice cream");
            Console.WriteLine("[3] Delete an existing ice cream");

            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Select an ice cream to modify (enter the number): ");
                int iceCreamIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                IceCream selectedIceCream = currentOrder.IceCreamList[iceCreamIndex];
                if (selectedIceCream is Cone cone)
                {
                    Console.Write("Modify Cone - Enter new information:\n");
                    Console.Write("Option (e.g., cup, cone, waffle): ");
                    cone.Option = Console.ReadLine();
                    Console.Write("Number of Scoops: ");
                    cone.Scoops = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Dipped Cone (true/false): ");
                    cone.Dipped = Convert.ToBoolean(Console.ReadLine());
                }
                if (selectedIceCream is Waffle waffle)
                {
                    Console.Write("Modify Waffle - Enter new information:\n");
                    Console.Write("Option (e.g., cup, cone, waffle): ");
                    waffle.Option = Console.ReadLine();
                    Console.Write("Number of Scoops: ");
                    waffle.Scoops = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Waffle Flavour: ");
                    waffle.WaffleFlavour = Console.ReadLine();
                }
            }
            
            
            /*
            Console.WriteLine("Which Icecream would you like to modify? : ");
            string modicecream = Console.ReadLine();
            Console.WriteLine("Please choose one of the following: Cup, Cone or Waffle");
            Console.WriteLine("Choice: ");
            string newicecreamtype = Console.ReadLine();
            Console.WriteLine("Please choose number of scoops of icecream: ");
            int newscoopcount = Convert.ToInt32(Console.ReadLine());
            if(newscoopcount == 0)
            {
               Console.WriteLine("Please choose a number between 1 to 3");
            }
            else if(newscoopcount == 1)
            {
                Console.WriteLine("Please choose flavour type: ");
            }
            else if (newscoopcount == 2)
            {
                Console.WriteLine("Please choose flavour 1: ");
                Console.WriteLine("Please choose flavour 2: ");
            }
            else if (newscoopcount == 3)
            {
                Console.WriteLine("Please choose flavour 1: ");
                Console.WriteLine("Please choose flavour 2: ");
                Console.WriteLine("Please choose flavour 3: ");
            }
            else
            {
                Console.WriteLine("Please enter only 3 scoops.");
            }

            */

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
        public override string ToString()
        {
            return  $"ID: {Id} Time Received: {Timereceived}";
        }
    }
}
