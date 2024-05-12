using Domain.Interfaces;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private string file = AppDomain.CurrentDomain.BaseDirectory + "..//..//..//..//Domain//data//products.json";

        public List<Product> LoadProducts()
        {
            using StreamReader streamReader = new(file);
            var json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public void SaveProduct(Product product)
        {
            var products = LoadProducts();
            products.Add(product);
            var productsString = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(file, productsString);
        }
    }
}