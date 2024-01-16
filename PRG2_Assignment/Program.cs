using PRG2_Assignment;

int option;
List<IceCream> IceCreamList = new();
List<Order> oList = new();
List<Customer> customerList = new();
ReadCSV(customerList);
while (true)
{
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

            ModifyOrder();
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

static void ReadCustomerCSV(List<Customer> cList)
{
    string[] data = File.ReadAllLines("customers.csv");
    foreach (string line in data.Skip(1)) // Skip header
    {
        string[] customers = line.Split(',');
        string name = customers[0];
        int id = Convert.ToInt32(customers[1]);
        DateTime dob = DateTime.Parse(customers[2]);
        Customer customer = new(name, id, dob);
        cList.Add(customer);
    }
}

static void ReadOrderCSV(List<Order> oList)
{	
    string[] data = File.ReadAllLines("orders.csv");
    foreach (string line in data.Skip(1)) // Skip header
    {
        string[] orderinfo = line.Split(',');
        int orderID = Convert.ToInt32(orderinfo[0]);
        int memid = Convert.ToInt32(orderinfo[1]);
        DateTime received = DateTime.Parse(orderinfo[2]);
		DateTime fulfilled = DateTime.Parse(orderinfo[3]);
        string option = orderinfo[4];
        int scoops = Convert.ToInt32(orderinfo[5]);
        bool dipped = Convert.ToBoolean(orderinfo[6]);
        string waffleFlavour = orderinfo[7];
        List<Flavour> flavours = new(orderinfo[8], orderinfo[9], orderinfo[10]);
		list<Toppings> toppings = new(orderinfo[11], orderinfo[12], orderinfo[13], orderinfo[14]);
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
static void ModifyOrder()
{
    
    Console.Write("\r\n---------------- M E N U -----------------\r\n" +
    "[1] Modify an existing iceream\r\n" +
    "[2] Add a new icecream\r\n" +
    "[3] Delete an icecream\r\n" +
    "[0] Exit/Cancel\r\n" +
    "Enter your option: ");
    int option1 = Convert.ToInt32(Console.ReadLine());
    if (option1 == 0)
    {
        return;
    }
    else if ( option1 == 1)
    {
        
    }

}