using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain
{
    public class Order
    {
        private readonly IProductRepository _productRepository;
        private List<OrderItem> OrderItems { get; set; } = [];

        public Order(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(string productId, int quantity)
        {
            var products = _productRepository.LoadProducts();
            var product = products?.FirstOrDefault(r => r.Id == productId);
            if(product == null)
            {
                throw new ProductNotFoundException("Product Id not found.");
            }
            var orderItem = new OrderItem { Product = product, Quantity = quantity };
            OrderItems.Add(orderItem);
        }

        public decimal CalculateTotal()
        {
            return OrderItems.Sum(r=> r.Quantity * r.Product.Price);
        }

        public void DisplayOrderDetails()
        {
            Console.WriteLine("Order Details:");
            foreach (var item in OrderItems)
            {
                Console.WriteLine($"Product Name: {item.Product.Name}, Price: {item.Product.Price}, Quantity: {item.Quantity}");
            }
            Console.WriteLine($"Total Order Price: {CalculateTotal()}");
        }
    }
}
