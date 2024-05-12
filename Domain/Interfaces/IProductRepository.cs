namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> LoadProducts();
        void SaveProduct(Product product);
    }
}