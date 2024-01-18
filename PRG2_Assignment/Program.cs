using PRG2_Assignment;
using System.Collections.Generic;
List<Topping> toppingsList = new();
List<Flavour> flavourList = new();
List<IceCream> iceCreamList = new();
List<Order> oList = new();
List<Customer> customerList = new();
ReadCustomerCsv(customerList);
ReadOrderCsv(oList);
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
        else if (option == 1)
        {
            ListCustomers(customerList);
        }
        else if (option == 2)
        {
            ListCurrentOrders();
        }
        else if (option == 3)
        {
            CustomerReg();
        }
        else if (option == 4)
        {
            CreateOrder();
        }
        else if (option == 5)
        {
            DisplayOrder();
        }
        else if (option == 6)
        {
            ListCustomers(customerList);
            
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
static void ReadOrderCsv(List<Order> oList)
{	
    string[] data = File.ReadAllLines("orders.csv");
    foreach (string line in data.Skip(1)) // Skip header
    {
        string[] orderinfo = line.Split(',');
        int orderId = Convert.ToInt32(orderinfo[0]);
        int memid = Convert.ToInt32(orderinfo[1]);
        DateTime received = DateTime.Parse(orderinfo[2]);
		DateTime fulfilled = DateTime.Parse(orderinfo[3]);
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
static void ListCurrentOrders()
{
    
}
//3
static void CustomerReg()
{

}
//4
static void CreateOrder()
{

}
//5
static void DisplayOrder()
{

}
//6
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
                break;
            }
        }
        if (selectedCustomer == null)
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
        Order currentorder = selectedCustomer.CurrentOrder;
        int orderid = currentorder.Id;
        currentorder.ModifyIceCream(orderid);
    }
    else if (option1 == 2)
    {
        
    }

}