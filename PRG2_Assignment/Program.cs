using PRG2_Assignment;

int option;
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
            ListCustomers();
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

//1
static void ListCustomers() 
    
{

}
//2
static void ListCurrentOrders()
{
    foreach (var a in List < IceCream > IceCreamList)
        Console.WriteLine(a);
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

}