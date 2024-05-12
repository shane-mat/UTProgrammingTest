using Domain.Interfaces;

namespace Domain
{
    public class DiscountManager : IDiscountManager
    {
        readonly Discount[] Discounts = [
            new Discount{  Percentage = 0.15m, Threshold = 100 },
            new Discount{  FixedAmount = 50, Threshold = 1000 }
        ];

        public void ApplyDiscount(Product product)
        {
            var discount = Discounts.OrderBy(d => d.Threshold).Where(d => d.Threshold <= product.Price).LastOrDefault();
            if (discount != null)
            {
                var discountedPrice = (discount.FixedAmount > 0) ? 
                    product.Price - discount.FixedAmount : product.Price * (1m - discount.Percentage);
                product.Price = discountedPrice;
            }
        }
    }
}
