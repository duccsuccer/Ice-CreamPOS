using PRG2_Assignment;
using System.Collections.Generic;
List<Topping> toppingsList = new();
List<Flavour> flavourList = new();
List<IceCream> iceCreamList = new();
List<Order> oList = new();
List<Customer> customerList = new();
ReadCustomerCsv(customerList);
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
            ListCurrentOrders(customerList);
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
            DisplayOrder(customerList);
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
            string tier = customers[3];
            int pts = Convert.ToInt32(customers[4]);
            int punchcard = Convert.ToInt32(customers[5]);


            Customer customer = new(name, id, dob);
            customer.Rewards = new(pts, punchcard);
            customer.Rewards.Tier = tier;
            cList.Add(customer);
        }
    }
static void ReadFlavoursCsv(List<Flavour> fList)
{
    string[] data = File.ReadAllLines("flavours.csv");
    foreach (string line in data.Skip(1))
    {
        
        string[] flavourinfo = line.Split(",");
        string name = flavourinfo[0];
        int cost = Convert.ToInt32(flavourinfo[1]);
        bool premium = (cost == 2);
        Flavour flavour = new(name, premium, 1);
        fList.Add(flavour);
    }

}
//1--------------------------------------------------------------------------------------------------------------------------------------------------------
static void ListCustomers(List<Customer> cList) 
{
    foreach (Customer customer in cList)
    {
        Console.WriteLine(customer.ToString());
    }
}
//2-----------------------------------------------------------------------------------------------------------------------------------------------------------
static void ListCurrentOrders(List<Customer> customerList)
{
    bool ispremium = false;
    List<Flavour> fList = new();
    string[] fdata = File.ReadAllLines("flavours.csv");
    foreach (string line in fdata.Skip(1))
    {
        string[] flavourinfo = line.Split(",");
        string name = flavourinfo[0];
        int cost = Convert.ToInt32(flavourinfo[1]);
        if (cost == 2)
        {
            ispremium = true;
        }
        Flavour flavour = new(name, ispremium, 1);
        fList.Add(flavour);
    }

    List<Order> oList = new();
    List<IceCream> icList = new();
    
    string[] data = File.ReadAllLines("orders.csv");
    foreach (string line in data.Skip(1)) // Skip header
    {
        List<Flavour> flavours = new();
        List<Topping> toppings = new();
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
        bool prem = false;
        string option = orderinfo[4];
        int scoops = Convert.ToInt32(orderinfo[5]);
        string waffleflav = orderinfo[7];
        string ft1 = orderinfo[8];
        string ft2 = orderinfo[9];
        string ft3 = orderinfo[10];
        foreach (Flavour flavour in fList)
        {
            if (flavour.Ftype == ft1 && flavour.Premium == true)
            {
                prem = true;
            }
            if (flavour.Ftype == ft2 && flavour.Premium == true)
            {
                prem = true;
            }
            if (flavour.Ftype == ft3 && flavour.Premium == true)
            {
                prem = true;
            }
        }
       
        Flavour f1 = new(ft1, prem, 1);
        Flavour f2 = new(ft2, prem, 1);
        Flavour f3 = new(ft3, prem, 1);
        flavours.Add(f1);
        flavours.Add(f2);
        flavours.Add(f3);
        Topping t1 = new(orderinfo[11]);
        Topping t2 = new(orderinfo[12]);
        Topping t3 = new(orderinfo[13]);
        Topping t4 = new(orderinfo[14]);
        toppings.Add(t1);
        toppings.Add(t2);
        toppings.Add(t3);
        toppings.Add(t4);
        // Filter toppings with non-empty Toptype
        List<Topping> filteredToppings = toppings.Where(t => !string.IsNullOrEmpty(t.Toptype)).ToList();
        toppings = filteredToppings;

        // Filter flavours with non-empty Ftype
        List<Flavour> filteredFlavours = flavours.Where(f => !string.IsNullOrEmpty(f.Ftype)).ToList();
        flavours = filteredFlavours;
        if (option == "Cup")
        {
            Cup ic = new(option, scoops, flavours, toppings);
            icList.Add(ic);
        }
        else if (option == "Waffle")
        {
            Waffle ic = new(option, scoops, flavours, toppings, waffleflav);
            icList.Add(ic);
        }
        else if (option == "Cone")
        {
            bool dipped = Convert.ToBoolean(orderinfo[6]);
            Cone ic = new(option, scoops, flavours, toppings, dipped);
            icList.Add(ic);
        } 
    }
        
    Console.WriteLine("\r\n---------------- Current Orders -----------------\r\n");
    int i = 0;
    foreach (Order order in oList)
    {
        
        if (order.Timefufilled == null)
        {
            Console.WriteLine(order.ToString());

            // Find the customer for the order
            Customer customer = customerList.Find(c => c.Memberid == order.Memberid);
            if (customer != null)
            {
                Console.WriteLine($"Customer: {customer.Name}");
                customer.OrderHistory.Add(order);
            }
            Console.WriteLine($"Total Price: {icList[i].CalculatePrice():C2}");
            Console.WriteLine("Ice Creams in Order:");
            Console.WriteLine($" - {icList[i].ToString()}");
            i++;
            Console.WriteLine("------------------------------------------\r\n");
        }
    }
}
//3 ------------------------------------------------------------------------------------------------------------------------------------------------------
static void CustomerReg(List<Customer> customerList)
{
    Random random = new();
    Console.Write("Name: ");
    string name = Console.ReadLine();
    int id = random.Next(100000, 999999);
    Console.Write("Date of Birth(dd/mm/yyyy): ");
    DateTime dob = Convert.ToDateTime(Console.ReadLine());
    Customer newCustomer = new(name, id, dob);
    string customerInfo = $"\n{name},{id},{dob.Date}";
    customerList.Add(newCustomer);
    File.AppendAllText("customers.csv", customerInfo);
}
//4 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
static void CreateOrder(List<Customer> customerList, List<Order> oList, List<Flavour> flavourList, List<Topping> toppingsList)
{
    
    Queue<Order> goldMemberOrderQueue = new Queue<Order>();
    Queue<Order> regularOrderQueue = new Queue<Order>();
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
            string flavors = "";
            string toppings = "";
            iceCream = new Cup("Cup", scoops, selectedFlavours, selectedToppings);
            
            if (selectedToppings.Count == 0)
            {
                File.AppendAllText("orders.csv", $"\n{newOrder.Id},{selectedCustomer.Memberid},{newOrder.Timereceived},,{option},{scoops},,,{flavors},,,{toppings},,,,");
            }
            flavors = string.Join(", ", selectedFlavours.Select(flavour => flavour.Ftype));
            toppings = string.Join(", ", selectedToppings.Select(topping => topping.Toptype));
            

        }
        File.AppendAllText("orders.csv", $"\n{newOrder.Id},{selectedCustomer.Memberid},{newOrder.Timereceived},,{option},{scoops},,,{flavors},{toppings}");
        else if (option.ToLower() == "cone")
        {
            string flavors = "";
            string toppings = "";
            bool dipped = false;
            Console.Write("Dipped? Y/N");
            string yesno = Console.ReadLine();
            if (yesno.ToUpper() == "Y") { dipped = true; }
            iceCream = new Cone("Cone", scoops, selectedFlavours, selectedToppings, dipped);
            if (selectedToppings.Count == 0)
            {
                File.AppendAllText("orders.csv", $"\n{newOrder.Id},{selectedCustomer.Memberid},{newOrder.Timereceived},,{option},{scoops},{dipped},,{flavors},{toppings},,,");

            }

            flavors = string.Join(", ", selectedFlavours.Select(flavour => flavour.Ftype));
            toppings = string.Join(", ", selectedToppings.Select(topping => topping.Toptype));
            File.AppendAllText("orders.csv", $"\n{newOrder.Id},{selectedCustomer.Memberid},{newOrder.Timereceived},,{option},{scoops},{dipped},,{flavors},{toppings}");
            
        }
        else if (option.ToLower() == "waffle")
        {
            string flavors = "";
            string toppings = "";
            List<string> waffleflavours = new();
            waffleflavours.Add("Red Velvet");
            waffleflavours.Add("Charcoal");
            waffleflavours.Add("Pandan");
            waffleflavours.Add("Standard");


            Console.WriteLine("Waffle Flavours: ");
            foreach (string flavour in waffleflavours)
            {
            Console.WriteLine(flavour);

            }
            Console.WriteLine("Choose flavour: ");
            string select = Console.ReadLine();

            foreach (string flavour in waffleflavours)
            {
                if (select == flavour.ToLower())
                {
                    select = flavour;
                }
            }
            iceCream = new Waffle("Waffle", scoops, selectedFlavours, selectedToppings, select);
            if (selectedToppings.Count == 0)
            {
                File.AppendAllText("orders.csv", $"\n{newOrder.Id},{selectedCustomer.Memberid},{newOrder.Timereceived},,{option},{scoops},,{select},{flavors},,,{toppings},,,,");
            }
            flavors = string.Join(", ", selectedFlavours.Select(flavour => flavour.Ftype));
            toppings = string.Join(", ", selectedToppings.Select(topping => topping.Toptype));
            File.AppendAllText("orders.csv", $"\n{newOrder.Id},{selectedCustomer.Memberid},{newOrder.Timereceived},,{option},{scoops},,{select},{flavors},{toppings}");
        }
        // Add the ice cream to the order
        newOrder.AddIceCream(iceCream);
        
        Console.Write("Add another ice cream to the order? (Y/N): ");
    } while (Console.ReadLine().ToUpper() == "Y");



    // dont know how to add to queue
    if (selectedCustomer.Rewards.Tier == "Gold")
    {
        // Append the order to the gold members order queue
        goldMemberOrderQueue.Enqueue(newOrder);
    }
    else
    {
        // Append the order to the regular order queue
        regularOrderQueue.Enqueue(newOrder);
    }
    Console.WriteLine("Order has been made successfully.");
    
}
//5----------------------------------------------------------------------------------------------------------------------------------------------------------------------
static void DisplayOrder(List<Customer> customerList)
{

    bool ispremium = false;
    List<Flavour> fList = new();
    string[] fdata = File.ReadAllLines("flavours.csv");
    foreach (string line in fdata.Skip(1))
    {
        string[] flavourinfo = line.Split(",");
        string name = flavourinfo[0];
        int cost = Convert.ToInt32(flavourinfo[1]);
        if (cost == 2)
        {
            ispremium = true;
        }
        Flavour flavour = new(name, ispremium, 1);
        fList.Add(flavour);
    }

    List<Order> oList = new();
    List<IceCream> icList = new();
    Console.WriteLine("\r\n---------------- Customers -----------------\r\n");
    ListCustomers(customerList);
    string[] data = File.ReadAllLines("orders.csv");
    try
    {
        Console.Write("Enter member ID to display orders: ");
        int memberId = Convert.ToInt32(Console.ReadLine());
                 
        int i = 0;

    foreach (string line1 in data.Skip(1))
    {
        string[] orderinfo = line1.Split(',');
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
        List<Flavour> flavours = new();
        List<Topping> toppings = new();
        bool prem = false;
        string option = orderinfo[4];
        int scoops = Convert.ToInt32(orderinfo[5]);
        string waffleflav = orderinfo[7];
        string ft1 = orderinfo[8];
        string ft2 = orderinfo[9];
        string ft3 = orderinfo[10];
        foreach (Flavour flavour in fList)
        {
            if (flavour.Ftype == ft1 && flavour.Premium == true)
            {
                prem = true;
            }
            if (flavour.Ftype == ft2 && flavour.Premium == true)
            {
                prem = true;
            }
            if (flavour.Ftype == ft3 && flavour.Premium == true)
            {
                prem = true;
            }
        }

        Flavour f1 = new(ft1, prem, 1);
        Flavour f2 = new(ft2, prem, 1);
        Flavour f3 = new(ft3, prem, 1);
        flavours.Add(f1);
        flavours.Add(f2);
        flavours.Add(f3);
        Topping t1 = new(orderinfo[11]);
        Topping t2 = new(orderinfo[12]);
        Topping t3 = new(orderinfo[13]);
        Topping t4 = new(orderinfo[14]);
        toppings.Add(t1);
        toppings.Add(t2);
        toppings.Add(t3);
        toppings.Add(t4);
        // Filter toppings with non-empty Toptype
        List<Topping> filteredToppings = toppings.Where(t => !string.IsNullOrEmpty(t.Toptype)).ToList();
        toppings = filteredToppings;

        // Filter flavours with non-empty Ftype
        List<Flavour> filteredFlavours = flavours.Where(f => !string.IsNullOrEmpty(f.Ftype)).ToList();
        flavours = filteredFlavours;


        
        // Find the customer for the order
        Customer customer = customerList.Find(c => c.Memberid == memberId);
            if (customer != null && customer.Memberid == memid)
            {
                    
                Console.WriteLine($"Customer: {customer.Name}");
                Order order = new(orderId, received);
                customer.OrderHistory.Add(order);
                oList.Add(order);
                if (option == "Cup")
                {
                    Cup ic = new(option, scoops, flavours, toppings);
                    icList.Add(ic);
                }
                else if (option == "Waffle")
                {
                    Waffle ic = new(option, scoops, flavours, toppings, waffleflav);
                    icList.Add(ic);
                }
                else if (option == "Cone")
                {
                    bool dipped = Convert.ToBoolean(orderinfo[6]);
                    Cone ic = new(option, scoops, flavours, toppings, dipped);
                    icList.Add(ic);
                }
                Console.WriteLine(order.ToString());
                Console.WriteLine($"Total Price: {icList[i].CalculatePrice():C2}");
                Console.WriteLine("Ice Creams in Order:");
                Console.WriteLine($" - {icList[i].ToString()}");
                i++;
                Console.WriteLine("------------------------------------------\r\n");
                
            }
                
                
        }


    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid integer for the member ID.");
    }
 }
    //6
    //WORKING IN PROGRESS DONT MARK AH --------------------------------------------------------------------------------------------------------
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
    catch (FormatException)
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
    else if (option1 == 3)
    {

    }
    else if (option1 == 0)
    {

    }

}

