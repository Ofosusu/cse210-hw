using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
   
List<Product> order1Products = new List<Product>();

order1Products.Add(new Product("Laptop", "P101", 900, 1));
order1Products.Add(new Product("Mouse", "P102", 25, 2));

Address address1 = new Address(
    "123 Main Street",
    "Phoenix",
    "Arizona",
    "USA");

Customer customer1 = new Customer("John Smith", address1);

Order order1 = new Order(customer1, order1Products);


List<Product> order2Products = new List<Product>();

order2Products.Add(new Product("Keyboard", "P201", 60, 1));
order2Products.Add(new Product("Monitor", "P202", 250, 2));
order2Products.Add(new Product("USB Cable", "P203", 10, 3));

Address address2 = new Address(
    "15 Oxford Street",
    "Accra",
    "Greater Accra",
    "Ghana");

Customer customer2 = new Customer("David Amoah", address2);

Order order2 = new Order(customer2, order2Products);


Console.WriteLine("ORDER 1");
Console.WriteLine("----------------------------");

Console.WriteLine("Packing Label");
Console.WriteLine(order1.GetPackingLabel());

Console.WriteLine("Shipping Label");
Console.WriteLine(order1.GetShippingLabel());

Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");

Console.WriteLine();


Console.WriteLine("ORDER 2");
Console.WriteLine("----------------------------");

Console.WriteLine("Packing Label");
Console.WriteLine(order2.GetPackingLabel());

Console.WriteLine("Shipping Label");
Console.WriteLine(order2.GetShippingLabel());

Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
 }
}
