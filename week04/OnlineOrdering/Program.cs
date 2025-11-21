using System;

class Program
{
    static void Main(string[] args)
    {
        // --------- First Order (USA customer) ----------
        Address address1 = new Address(
            "123 Main Street",
            "Phoenix",
            "AZ",
            "USA");

        Customer customer1 = new Customer("Sarah Johnson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P1001", 19.99m, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P1002", 59.99m, 1));
        order1.AddProduct(new Product("USB-C Cable", "P1003", 5.50m, 3));

        // --------- Second Order (International customer) ----------
        Address address2 = new Address(
            "45 King Street",
            "Toronto",
            "ON",
            "Canada");

        Customer customer2 = new Customer("David Miller", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Noise Cancelling Headphones", "P2001", 120.00m, 1));
        order2.AddProduct(new Product("Laptop Stand", "P2002", 35.00m, 2));

        // --------- Display results for each order ----------
        Console.WriteLine("===== ORDER 1 =====");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine();

        Console.WriteLine("===== ORDER 2 =====");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
        Console.WriteLine();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
