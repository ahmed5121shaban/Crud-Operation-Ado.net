using System;
using Manegers;
using Models;
public static class Program
{
    public static void DisplyCustomer()
    {
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.Clear();
        for (int i = 0; i < 2; i++)
            Console.WriteLine(new string('-', 120));
        Console.WriteLine(" 1 - Add Customer.\n" +
                          " 2 - Get All Customers.\n" +
                          " 3 - Get Customer By ID.\n" +
                          " 4 - Update Customer.\n" +
                          " 5 - Delete Customer.\n" +
                          " 6 - Return To Menu\n");
        Console.Write("Enter your Choise : ");
        int No = int.Parse(Console.ReadLine());
        CustomerManeger customer = new CustomerManeger();
        switch (No)
        {
            case 1:
                Console.Write("\nEnter Customer Name : ");
                try { 
                    customer.Add(new Customer { Name = Console.ReadLine() });
                    Console.WriteLine("Added Done :)");
                } catch { Console.WriteLine("Not Added :("); }
                break;
            case 2:
                foreach (var item in customer.getAll())
                    {
                        Console.WriteLine(item);
                    }
                break;
            case 3:
                Console.Write("\nEnter Customer ID : ");
                try
                {
                    Console.WriteLine(customer.getById(int.Parse(Console.ReadLine())));
                }catch { Console.WriteLine("ID Not Found :("); }
                break;
            case 4:
                Console.Write("\nEnter Customer ID you want to update : ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("\nEnter Customer Name : ");
                string name = Console.ReadLine();
                try { 
                    if(customer.Update(new Customer { ID = id, Name = name }))
                        Console.WriteLine("\nUpdated :)");
                    Console.WriteLine("\nID not Found :(");
                } catch { Console.WriteLine("\nID not Found :("); }
                break;
            case 5:
                Console.Write("\nEnter Customer ID you want to Delete : ");
                int idd = int.Parse(Console.ReadLine());
                try
                {
                    if(customer.Delete(new Customer { ID = idd }))
                        Console.WriteLine("\nDeleted :)");
                    Console.WriteLine("\nID not Found :(");
                }
                catch { Console.WriteLine("\nID not Found :("); }
                break;
            case 6:
                Disply();
                break;
        }
        Console.Write("\nTo Do Another Operations Press [y,Y] To Return To Menu Press Any Key : ");
        switch ((Console.ReadLine().ToLower()))
        {
            case "y":
                DisplyCustomer();
                break;
            default:
                Disply();
                break;
        }
    }
    public static void DisplyOrder()
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.Clear();
        for (int i = 0; i < 2; i++)
            Console.WriteLine(new string('-', 120));
        Console.WriteLine(" 1 - Add Order.\n" +
                          " 2 - Get All Orders.\n" +
                          " 3 - Get Order By ID.\n" +
                          " 4 - Update Order.\n" +
                          " 5 - Delete Order.\n" +
                          " 6 - Return To Menu\n");
        Console.Write("Enter your Choise : ");
        int No = int.Parse(Console.ReadLine());
        OrderManeger order = new OrderManeger();
        switch (No)
        {
            case 1:
                Console.Write("\nEnter Order Price : ");
                float price = float.Parse(Console.ReadLine());
                Console.Write("\nEnter Order Customer ID : ");
                int customer_ID = int.Parse(Console.ReadLine());
                try
                {
                    order.Add(new Order { Price = price,Customer_ID= customer_ID,DateTime = DateTime.Now });
                    Console.WriteLine("Added Done :)");
                }
                catch { Console.WriteLine("Not Added :("); }
                break;
            case 2:
                foreach (var item in order.getAll())
                {
                    Console.WriteLine(item);
                }
                break;
            case 3:
                Console.Write("\nEnter Order ID : ");
                try
                {
                    Console.WriteLine(order.getById(int.Parse(Console.ReadLine())));
                }
                catch { Console.WriteLine("ID Not Found :("); }
                break;
            case 4:
                Console.Write("\nEnter Order ID you want to update : ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("\nEnter Order Price : ");
                float priceu = float.Parse(Console.ReadLine());
                Console.Write("\nEnter Order Customer ID : ");
                int customer_IDu = int.Parse(Console.ReadLine());
                try
                {
                    if(order.Update(new Order { ID = id, Price = priceu,Customer_ID= customer_IDu , DateTime=DateTime.Now}))
                        Console.WriteLine("\nUpdated :)");
                    Console.WriteLine("\nID not Found :(");
                }
                catch { Console.WriteLine("\nID not Found :("); }
                break;
            case 5:
                Console.Write("\nEnter Order ID you want to Delete : ");
                int idd = int.Parse(Console.ReadLine());
                try
                {
                    if(order.Delete(new Order { ID = idd }))
                        Console.WriteLine("\nDeleted :)");
                    Console.WriteLine("\nID not Found :(");
                }
                catch { Console.WriteLine("\nID not Found :("); }
                break;
            case 6:
                Disply();
                break;
        }
        Console.Write("\nTo Do Another Operations Press [y,Y] To Return To Menu Press Any Key : ");
        switch ((Console.ReadLine().ToLower()))
        {
            case "y":
                DisplyOrder();
                break;
            default:
                Disply();
                break;
        }
    }
    public static void Disply()
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Clear();

        for (int i = 0; i < 2; i++)
            Console.WriteLine(new string('-', 120));

        Console.WriteLine("what's the Table You want : ");
        Console.WriteLine(" 1 - Customer.\n" +
                          " 2 - Order.");
        Console.Write("Enter your Choise OR Press Any Key To Exit : ");
        try { 
            int No = int.Parse(Console.ReadLine());
            if (No == 1)
                DisplyCustomer();
            else if (No == 2)
                DisplyOrder();
            else
                return;

        } catch { return; }
        
        

    }
    public static int Main()
    {

        Disply();

        return 0;
    }
}