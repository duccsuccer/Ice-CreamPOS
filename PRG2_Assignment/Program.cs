using PRG2_Assignment;
using System.Collections.Generic;
List<Topping> toppingsList = new();
List<Flavour> flavourList = new();
List<IceCream> iceCreamList = new();
List<Order> oList = new();
List<Customer> customerList = new();
ReadCustomerCsv(customerList);
ReadOrderCsv(oList,customerList);
ReadFlavoursCsv(flavourList);
ReadToppingsCsv(toppingsList);
while (true)
{
    int option;
    try
    { 

        DisplayMenu();
        option = Convert.ToInt32(Console.ReadLine());
        if (option == 0)
        {
            break;
        }
        if (option == 1)
        {
            ListCustomers(customerList);
        }
        else if (option == 2)
        {
            ListCurrentOrders(oList, customerList);
        }
        else if (option == 3)
        {
            CustomerReg(customerList);
        }
        else if (option == 4)
        {
            CreateOrder(customerList, oList,  flavourList,  toppingsList);
        }
        else if (option == 5)
        {
            DisplayOrder();
        }
        else if (option == 6)
        {
            
            ModifyOrder(customerList);
        }
        else
        {
            Console.WriteLine("Please enter a number within the menu");
        }
    }
    catch(FormatException)
    {
        Console.WriteLine("Please enter a number!");
    }
    
}
static void DisplayMenu()
{
    Console.Write("\r\n---------------- M E N U -----------------\r\n" +
    "[1] List all customers\r\n" +
    "[2] List all current orders\r\n" +
    "[3] Register a new customer\r\n" +
    "[4] Create a customer's order\r\n" +
    "[5] Display order details of a customer\r\n" +
    "[6] Modify order details\r\n" +
    "[0] Exit\r\n------------------------------------------\r\n" +
    "Enter your option : ");

}

static void ReadToppingsCsv(List<Topping> tList)
{
    string[] data = File.ReadAllLines("customers.csv");
    foreach(string line in data.Skip(1)) 
    {
        string[] topinfo = line.Split(",");
        string name = topinfo[0];
        Topping topping = new Topping(name);
        tList.Add(topping);
    }
}
static void ReadCustomerCsv(List<Customer> cList)
{
    string[] data = File.ReadAllLines("customers.csv");
    foreach (string line in data.Skip(1)) // Skip header
    {
        string[] customers = line.Split(",");
        string name = customers[0];
        int id = Convert.ToInt32(customers[1]);
        DateTime dob = DateTime.Parse(customers[2]);
        Customer customer = new(name, id, dob);
        cList.Add(customer);
    }
}
static void ReadFlavoursCsv(List<Flavour> fList)
{
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

}
static void ReadOrderCsv(List<Order> oList, List<Customer> customerList)
{	
    string[] data = File.ReadAllLines("orders.csv");
    foreach (string line in data.Skip(1)) // Skip header
    {
        string[] orderinfo = line.Split(',');
        int orderId = Convert.ToInt32(orderinfo[0]);
        int memid = Convert.ToInt32(orderinfo[1]);
        DateTime received = DateTime.Parse(orderinfo[2]);
        DateTime? fulfilled;

        if (string.IsNullOrEmpty(orderinfo[3]))
        {
            fulfilled = null;
        }
        else
        {
            fulfilled = DateTime.Parse(orderinfo[3]);
        }
        Order order = new(orderId, received);
        oList.Add(order);
    }
}
    
//1
static void ListCustomers(List<Customer> cList) 
{
    foreach (Customer customer in cList)
    {
        Console.WriteLine(customer.ToString());
    }
}
//2
static void ListCurrentOrders(List<Order> oList, List<Customer> customerList)
{
    List<IceCream> icList = new();
    List<Flavour> flavours = new();
    List<Topping> toppings = new();
    string[] data = File.ReadAllLines("orders.csv");
    foreach (string line in data.Skip(1)) // Skip header
    {
        string[] orderinfo = line.Split(',');
        string option = orderinfo[4];
        int scoops = Convert.ToInt32(orderinfo[5]);
        bool dipped = Convert.ToBoolean(orderinfo[6]);
        string waffleflav = orderinfo[7];
        string f1 = orderinfo[8];
        string f2 = orderinfo[9];
        string f3 = orderinfo[10];
        Topping t1 = new(orderinfo[11]);
        Topping t2 = new(orderinfo[12]);
        Topping t3 = new(orderinfo[13]);
        Topping t4 = new(orderinfo[14]);
        toppings.Add(t1);
        toppings.Add(t2);
        toppings.Add(t3);
        toppings.Add(t4);
        if (option.ToLower() == "cup")
        {
            Cup ic = new(option, scoops, flavours, toppings);
            icList.Add(ic);
        }
        else if(option.ToLower() == "waffle")
        {
            Waffle ic = new(option, scoops, flavours, toppings, waffleflav);
            icList.Add(ic);
        }
        else if (option.ToLower() == "cone")
        {
            Cone ic = new(option, scoops, flavours, toppings, dipped);
            icList.Add(ic);
        }
    }

    Console.WriteLine("\r\n---------------- Current Orders -----------------\r\n");

    foreach (Order order in oList)
    {
        icList = order.IceCreamList;
        if (order.Timefufilled == null)
        {
            Console.WriteLine(order.ToString());

            // Find the customer for the order
            Customer customer = customerList.Find(c => c.Memberid == order.Memberid);
            if (customer != null)
            {
                Console.WriteLine($"Customer: {customer.Name}");
            }

            Console.WriteLine($"Total Price: {order.CalculateTotal():C2}");
            Console.WriteLine("Ice Creams in Order:");

            foreach (IceCream iceCream in order.IceCreamList)
            {
                Console.WriteLine($"  - {iceCream}");
            }

            Console.WriteLine("------------------------------------------\r\n");
        }
    }

}
//3
static void CustomerReg(List<Customer> customerList)
{
    Random random = new();
    Console.Write("Name: ");
    string name = Console.ReadLine();
    int id = random.Next(100000, 999999);
    Console.Write("Date of Birth(dd/mm/yyyy): ");
    DateTime dob = Convert.ToDateTime(Console.ReadLine());
    Customer newCustomer = new(name, id, dob);
    string customerInfo = $"{name},{id},{dob.Date}";
    customerList.Add(newCustomer);
    File.AppendAllText("customers.csv", customerInfo);
}
//4
static void CreateOrder(List<Customer> customerList, List<Order> oList, List<Flavour> flavourList, List<Topping> toppingsList)
{
    Console.Write("Select a customer (Enter Member ID): ");
    int memberId = Convert.ToInt32(Console.ReadLine());

    // Find the selected customer
    Customer selectedCustomer = customerList.Find(c => c.Memberid == memberId);

    if (selectedCustomer == null)
    {
        Console.WriteLine("Customer not found.");
        return;
    }

    // Create a new order for the selected customer
    Order newOrder = new Order();
    newOrder.Id = oList.Count + 1; // Generate a new order ID
    newOrder.Timereceived = DateTime.Now;
    selectedCustomer.CurrentOrder = newOrder; // Link the new order to the customer

    do
    {
        // Prompt user to enter ice cream order details
        Console.Write("Enter option (e.g., cup, cone, waffle): ");
        string option = Console.ReadLine();

        Console.Write("Enter number of scoops: ");
        int scoops = Convert.ToInt32(Console.ReadLine());

        List<Flavour> selectedFlavours = new List<Flavour>();
        for (int i = 1; i <= scoops; i++)
        {
            Console.Write($"Enter flavour for scoop {i}: ");
            string flavourName = Console.ReadLine();
            Flavour selectedFlavour = null;

            foreach (Flavour flavour in flavourList)
            {
                if (flavour.Ftype.ToLower() == flavourName.ToLower())
                {
                    selectedFlavour = flavour;
                    break; // Exit the loop once a match is found
                }
            }

            selectedFlavours.Add(selectedFlavour);
        }

        List<Topping> selectedToppings = new List<Topping>();
        Console.Write("Do you want toppings? (Y/N): ");
        if (Console.ReadLine().ToUpper() == "Y")
        {
            Console.Write("Enter number of toppings: ");
            int numToppings = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= numToppings; i++)
            {
                Console.Write($"Enter topping {i}: ");
                string toppingName = Console.ReadLine();
                Topping selectedtopping = null;

                foreach (Topping topping in toppingsList)
                {
                    if (topping.Toptype.ToLower() == toppingName.ToLower())
                    {
                        selectedtopping = topping;
                        break; // Exit the loop once a match is found
                    }
                }

                selectedToppings.Add(selectedtopping);
            }
            
           }
        

        // Create the ice cream object with the entered information
        IceCream iceCream = null;
        if (option.ToLower() == "cup")
        {
            iceCream = new Cup(option, scoops, selectedFlavours, selectedToppings);
        }
        else if (option.ToLower() == "cone")
        {
            iceCream = new Cone(option, scoops, selectedFlavours, selectedToppings, false);
        }
        else if (option.ToLower() == "waffle")
        {
            iceCream = new Waffle(option, scoops, selectedFlavours, selectedToppings, "standard");
        }

        // Add the ice cream to the order
        newOrder.AddIceCream(iceCream);

        Console.Write("Add another ice cream to the order? (Y/N): ");
    } while (Console.ReadLine().ToUpper() == "Y");

    // dont know how to add to queue

    Console.WriteLine("Order has been made successfully.");
    
}
//5
static void DisplayOrder()
{

}
//6
 //WORKING IN PROGRESS DONT MARK AH
static void ModifyOrder(List<Customer> custList)
{
    Customer selectedCustomer = null;
    Console.Write("\r\n----------------Customers-----------------\r\n");
    ListCustomers(custList);
    try
    {
        bool found = false;
        Console.Write("Enter member ID: ");
        int cId = Convert.ToInt32(Console.ReadLine());
        foreach (Customer customer in custList)
        {
            if (cId == customer.Memberid)
            {
                Console.WriteLine("Customer found: " + customer.Name);
                selectedCustomer = customer;
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("Customer not found.");
            return;
        }
    }
    catch(FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid integer for the member ID.");
    }
    Console.Write("\r\n---------------- M E N U -----------------\r\n" +
    "[1] Modify an existing icecream\r\n" +
    "[2] Add a new icecream\r\n" +
    "[3] Delete an icecream\r\n" +
    "[0] Exit/Cancel\r\n" +
    "Enter your option: ");
    int option1 = Convert.ToInt32(Console.ReadLine());
    if (option1 == 0)
    {
        
    }
    else if (option1 == 1)
    {
        if (selectedCustomer.CurrentOrder != null)
        {
            Order currentorder = selectedCustomer.CurrentOrder;
            int orderid = currentorder.Id;
            currentorder.ModifyIceCream(orderid);
        }
        else
        {
            Console.WriteLine("No current order to modify");
        }
    }
    else if (option1 == 2)
    {
        
    }

}
