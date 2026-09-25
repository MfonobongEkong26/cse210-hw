using System;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1 - Customer in the USA
        Address address1 = new Address(
            "123 Main Street",
            "Seattle",
            "Washington",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Product product1 = new Product(
            "Laptop",
            "LAP001",
            800.00,
            1
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "MOU002",
            25.00,
            2
        );

        Product product3 = new Product(
            "Keyboard",
            "KEY003",
            45.00,
            1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Console.WriteLine("=================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("=================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalCost():F2}");

        // ORDER 2 - Customer outside the USA
        Address address2 = new Address(
            "15 Aba Road",
            "Port Harcourt",
            "Rivers State",
            "Nigeria"
        );

        Customer customer2 = new Customer(
            "Mfonobong",
            address2
        );

        Product product4 = new Product(
            "Office Chair",
            "CHA004",
            150.00,
            2
        );

        Product product5 = new Product(
            "Desk Lamp",
            "LAM005",
            35.00,
            1
        );

        Product product6 = new Product(
            "Notebook",
            "NOT006",
            10.00,
            3
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("=================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalCost():F2}");
    }
}