using System;
using System.Collections;
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
            List<Flavour> fList = new();
            string[] data = File.ReadAllLines("flavours.csv");
            foreach (string line in data.Skip(1))
            {
                bool premium = false;
                string[] flavourinfo = line.Split(",");
                string name = flavourinfo[0];
                int cost = Convert.ToInt32(flavourinfo[1]);
                if (cost == 2)
                {
                    premium = true;
                }
                Flavour flavour = new(name, premium, 1);
                fList.Add(flavour);
            }
            //List Customer ORDER 
            Console.WriteLine($"Ice Creams in Order (Order ID: {id}):");
            int i = 1;
            foreach (IceCream icecreams in IceCreamList)
            {

                Console.WriteLine($"[{i}] {icecreams}");
                i++;
            }


            //PROMPT CUSTOMER TO MODIFY 
            Console.Write("Select an ice cream to modify (enter the number): ");
            int iceCreamIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            IceCream selectedIceCream = IceCreamList[iceCreamIndex];
            
            //If customer choose to modify ice cream which is a cone...
            if (selectedIceCream.Option is "Cone")
            {
                Console.Write("Modify Cone - Enter new information:\n");
                Console.Write("Option (e.g., cup, cone, waffle): ");
                selectedIceCream.Option = Console.ReadLine();
                Console.Write("Number of Scoops: ");
                selectedIceCream.Scoops = Convert.ToInt32(Console.ReadLine());
                // After selecting number of scoops, we need the flavours of each scoop
                selectedIceCream.Flavours.Clear();

                if (selectedIceCream.Scoops == 0)
                {
                    Console.WriteLine("Please choose a number between 1 to 3");
                }
                else if (selectedIceCream.Scoops == 1)
                {
                    Console.Write("Please choose flavour type: ");
                    string flavourtype1 = Console.ReadLine();

                    Flavour newflavour = new Flavour(flavourtype1, false, 1);
                    foreach (Flavour flavour in fList)
                    {
                        if (newflavour == flavour && flavour.Premium == true)
                        {
                            newflavour.Premium = true;
                        }
                    }
                    selectedIceCream.Flavours.Add(newflavour);
                }
                else if (selectedIceCream.Scoops == 2)
                {
                    for (int a = 1; a < 3; a++)
                    { 
                        Console.Write($"Please choose flavour type {a} : ");
                        string flavourtype = Console.ReadLine();
                        Flavour newflavour = new Flavour(flavourtype, false, 1);
                        foreach (Flavour flavour in fList)
                        {
                            if (newflavour == flavour && flavour.Premium == true)
                            {
                                newflavour.Premium = true;
                            }
                        }
                        selectedIceCream.Flavours.Add(newflavour);
                    }
                }
                else if (selectedIceCream.Scoops == 3)
                {
                    for (int b = 1; b < 4; b++)
                    {
                        Console.Write($"Please choose flavour type {b} : ");
                        string flavourtype = Console.ReadLine();
                        Flavour newflavour = new Flavour(flavourtype, false, 1);
                        foreach (Flavour flavour in fList)
                        {
                            if (newflavour == flavour && flavour.Premium == true)
                            {
                                newflavour.Premium = true;
                            }
                        }
                        selectedIceCream.Flavours.Add(newflavour);
                    }
                }
                
                else
                {
                    Console.Write("Please enter only 3 scoops.");
                }

                //check if user want toppings
                Console.Write("Do you want toppings? [y/n] : ");
                string doesuserwanttoppings = Console.ReadLine();
                if (doesuserwanttoppings == "y")
                {
                    selectedIceCream.Toppings.Clear();
                    Console.Write("How many toppings do you want? :  ");
                    int numberofnewtoppings = Convert.ToInt32(Console.ReadLine());                   
                    for(int n = 1; n <= numberofnewtoppings ; n++)
                    {
                        Console.Write($"Enter Topping choice {n}: ");
                        string newtoppingtype = Console.ReadLine();
                        Topping newtopping = new Topping(newtoppingtype);
                        selectedIceCream.Toppings.Add(newtopping);
                    }
                }
                //if user new ice cream is cone, ask for dipp or not
                if (selectedIceCream.Option is "Cone")
                {
                    Console.Write("Dipped Cone (true/false): ");
                    Cone newcone = (Cone)selectedIceCream;
                    newcone.Dipped = Convert.ToBoolean(Console.ReadLine()); 
                }
                //if user new ice cream is waffle, ask for waffle flavour
                else if(selectedIceCream.Option is "Waffle")
                {
                    Console.Write("Waffle type: ");
                    Waffle newwaffle = (Waffle)selectedIceCream;
                    newwaffle.WaffleFlavour = Console.ReadLine();
                }
            }
            //If customer choose to modify ice cream which is a waffle...-------------------------------------
            if (selectedIceCream.Option is "Waffle")
            {
                Console.Write("Modify Waffle - Enter new information:\n");
                Console.Write("Option (e.g., cup, cone, waffle): ");
                selectedIceCream.Option = Console.ReadLine();
                Console.Write("Number of Scoops: ");
                selectedIceCream.Scoops = Convert.ToInt32(Console.ReadLine());
                // After selecting number of scoops, we need the flavours of each scoop
                selectedIceCream.Flavours.Clear();

                if (selectedIceCream.Scoops == 0)
                {
                    Console.WriteLine("Please choose a number between 1 to 3");
                }
                else if (selectedIceCream.Scoops == 1)
                {
                    Console.Write("Please choose flavour type: ");
                    string flavourtype1 = Console.ReadLine();

                    Flavour newflavour = new Flavour(flavourtype1, false, 1);
                    foreach (Flavour flavour in fList)
                    {
                        if (newflavour == flavour && flavour.Premium == true)
                        {
                            newflavour.Premium = true;
                        }
                    }
                    selectedIceCream.Flavours.Add(newflavour);
                }
                else if (selectedIceCream.Scoops == 2)
                {
                    for (int a = 1; a < 3; a++)
                    {
                        Console.Write($"Please choose flavour type {a} : ");
                        string flavourtype = Console.ReadLine();
                        Flavour newflavour = new Flavour(flavourtype, false, 1);
                        foreach (Flavour flavour in fList)
                        {
                            if (newflavour == flavour && flavour.Premium == true)
                            {
                                newflavour.Premium = true;
                            }
                        }
                        selectedIceCream.Flavours.Add(newflavour);
                    }
                }
                else if (selectedIceCream.Scoops == 3)
                {
                    for (int b = 1; b < 4; b++)
                    {
                        Console.Write($"Please choose flavour type {b} : ");
                        string flavourtype = Console.ReadLine();
                        Flavour newflavour = new Flavour(flavourtype, false, 1);
                        foreach (Flavour flavour in fList)
                        {
                            if (newflavour == flavour && flavour.Premium == true)
                            {
                                newflavour.Premium = true;
                            }
                        }
                        selectedIceCream.Flavours.Add(newflavour);
                    }
                }

                else
                {
                    Console.Write("Please enter only 3 scoops.");
                }

                //check if user want toppings
                Console.Write("Do you want toppings? [y/n] : ");
                string doesuserwanttoppings = Console.ReadLine();
                if (doesuserwanttoppings == "y")
                {
                    selectedIceCream.Toppings.Clear();
                    Console.Write("How many toppings do you want? :  ");
                    int numberofnewtoppings = Convert.ToInt32(Console.ReadLine());
                    for (int n = 1; n <= numberofnewtoppings; n++)
                    {
                        Console.Write($"Enter Topping choice {n}: ");
                        string newtoppingtype = Console.ReadLine();
                        Topping newtopping = new Topping(newtoppingtype);
                        selectedIceCream.Toppings.Add(newtopping);
                    }
                }
                //if user new ice cream is cone, ask for dipp or not
                if (selectedIceCream.Option is "Cone")
                {
                    Console.Write("Dipped Cone (true/false): ");
                    Cone newcone = (Cone)selectedIceCream;
                    newcone.Dipped = Convert.ToBoolean(Console.ReadLine());
                }
                //if user new ice cream is waffle, ask for waffle flavour
                else if (selectedIceCream.Option is "Waffle")
                {
                    Console.Write("Waffle type: ");
                    Waffle newwaffle = (Waffle)selectedIceCream;
                    newwaffle.WaffleFlavour = Console.ReadLine();
                }
            }
            //if user want to modify a cup------------------------------------------------------------------------------
            if (selectedIceCream.Option is "Cup")
            {
                Console.Write("Modify Cup - Enter new information:\n");
                Console.Write("Option (e.g., cup, cone, waffle): ");
                selectedIceCream.Option = Console.ReadLine();
                Console.Write("Number of Scoops: ");
                selectedIceCream.Scoops = Convert.ToInt32(Console.ReadLine());
                // After selecting number of scoops, we need the flavours of each scoop
                selectedIceCream.Flavours.Clear();

                if (selectedIceCream.Scoops == 0)
                {
                    Console.WriteLine("Please choose a number between 1 to 3");
                }
                else if (selectedIceCream.Scoops == 1)
                {
                    Console.Write("Please choose flavour type: ");
                    string flavourtype1 = Console.ReadLine();

                    Flavour newflavour = new Flavour(flavourtype1, false, 1);
                    foreach (Flavour flavour in fList)
                    {
                        if (newflavour == flavour && flavour.Premium == true)
                        {
                            newflavour.Premium = true;
                        }
                    }
                    selectedIceCream.Flavours.Add(newflavour);
                }
                else if (selectedIceCream.Scoops == 2)
                {
                    for (int a = 1; a < 3; a++)
                    {
                        Console.Write($"Please choose flavour type {a} : ");
                        string flavourtype = Console.ReadLine();
                        Flavour newflavour = new Flavour(flavourtype, false, 1);
                        foreach (Flavour flavour in fList)
                        {
                            if (newflavour == flavour && flavour.Premium == true)
                            {
                                newflavour.Premium = true;
                            }
                        }
                        selectedIceCream.Flavours.Add(newflavour);
                    }
                }
                else if (selectedIceCream.Scoops == 3)
                {
                    for (int b = 1; b < 4; b++)
                    {
                        Console.Write($"Please choose flavour type {b} : ");
                        string flavourtype = Console.ReadLine();
                        Flavour newflavour = new Flavour(flavourtype, false, 1);
                        foreach (Flavour flavour in fList)
                        {
                            if (newflavour == flavour && flavour.Premium == true)
                            {
                                newflavour.Premium = true;
                            }
                        }
                        selectedIceCream.Flavours.Add(newflavour);
                    }
                }

                else
                {
                    Console.Write("Please enter only 3 scoops.");
                }

                //check if user want toppings
                Console.Write("Do you want toppings? [y/n] : ");
                string doesuserwanttoppings = Console.ReadLine();
                if (doesuserwanttoppings == "y")
                {
                    selectedIceCream.Toppings.Clear();
                    Console.Write("How many toppings do you want? :  ");
                    int numberofnewtoppings = Convert.ToInt32(Console.ReadLine());
                    for (int n = 1; n <= numberofnewtoppings; n++)
                    {
                        Console.Write($"Enter Topping choice {n}: ");
                        string newtoppingtype = Console.ReadLine();
                        Topping newtopping = new Topping(newtoppingtype);
                        selectedIceCream.Toppings.Add(newtopping);
                    }
                }
                //if user new ice cream is cone, ask for dipp or not
                if (selectedIceCream.Option is "Cone")
                {
                    Console.Write("Dipped Cone (true/false): ");
                    Cone newcone = (Cone)selectedIceCream;
                    newcone.Dipped = Convert.ToBoolean(Console.ReadLine());
                }
                //if user new ice cream is waffle, ask for waffle flavour
                else if (selectedIceCream.Option is "Waffle")
                {
                    Console.Write("Waffle type: ");
                    Waffle newwaffle = (Waffle)selectedIceCream;
                    newwaffle.WaffleFlavour = Console.ReadLine();
                }
            
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
        public override string ToString()
        {
            return  $"ID: {Id} Time Received: {Timereceived}";
        }
    }
}