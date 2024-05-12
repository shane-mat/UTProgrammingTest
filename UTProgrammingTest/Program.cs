using Domain;
using Domain.Exceptions;
using Domain.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var shoppingCart = new ShoppingCart(new DiscountManager(), new ProductRepository());
        var order = new Order(new ProductRepository());

        Console.WriteLine("Welcome to our Online Shopping!\n");
        Console.WriteLine("Please enter one of the following options");
        Console.WriteLine("***************************************");
        Console.WriteLine("1 - List products in the cart");
        Console.WriteLine("2 - Add a product to the cart");
        Console.WriteLine("3 - Create an order");
        Console.WriteLine("4 - Display order details");
        Console.WriteLine("x - Close the application");

        try
        {
            while (true)
            {
                Console.Write("\n>");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) 
                    || input.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                switch (input)
                {
                    case "1":
                        shoppingCart.DisplayProducts();
                        break;
                    case "2":
                        Console.WriteLine("Please enter product details");
                        Console.Write("Product Id: ");
                        var id = Console.ReadLine();
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Price: ");
                        var price = Console.ReadLine();

                        if (string.IsNullOrEmpty(id)
                            || string.IsNullOrEmpty(name)
                            || string.IsNullOrEmpty(price) || !price.All(char.IsDigit))
                        {
                            throw new InvalidInputException("Invalid inputs.");
                        }
                        shoppingCart.Add(new Product
                        {
                            Id = id,
                            Name = name,
                            Price = decimal.Parse(price)
                        });
                        break;
                    case "3":
                        Console.WriteLine("Please add products and quantity");
                        Console.Write("Product Id: ");
                        id = Console.ReadLine();
                        Console.Write("Quantity: ");
                        var quantity = Console.ReadLine();
                        if (string.IsNullOrEmpty(id)
                            || string.IsNullOrEmpty(quantity) || !quantity.All(char.IsDigit))
                        {
                            throw new InvalidInputException("Invalid inputs.");
                        }
                        order.Add(id, int.Parse(quantity));
                        break;
                    case "4":
                        order.DisplayOrderDetails();
                        break;
                    default:
                        break;
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}