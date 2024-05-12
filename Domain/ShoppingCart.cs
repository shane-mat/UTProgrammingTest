using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain
{
    public class ShoppingCart
    {
        private readonly IDiscountManager _discountManager;
        private readonly IProductRepository _productRepository;

        public ShoppingCart(IDiscountManager discountManager, IProductRepository productRepository)
        {
            _discountManager = discountManager;
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            var products = _productRepository.LoadProducts();

            if (products.Any(r=> r.Id == product.Id)) 
            {
                throw new DuplicateProductException("Product Id already exists.");
            }
            _discountManager.ApplyDiscount(product);
            _productRepository.SaveProduct(product);
        }

        public void Remove(string productId) 
        {
            var products = _productRepository.LoadProducts();
            var product = products.FirstOrDefault(r => r.Id == productId);
            if (product == null)
            {
                throw new ProductNotFoundException("Product Id not found.");
            }
            products.Remove(product);
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Product list:");
            var products = _productRepository.LoadProducts();
            foreach (var product in products)
            {
                product.DisplayDetails();
            }
        }

        public decimal GetTotalPrice()
        {
            var products = _productRepository.LoadProducts();
            return products.Sum(r => r.Price);
        }
    }
}
