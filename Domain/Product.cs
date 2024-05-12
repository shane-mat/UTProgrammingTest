namespace Domain
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Price: {Price}"); 
        }
    }
}