namespace Domain
{
    public class Discount
    {
        public decimal Threshold { get; set; }
        public decimal Percentage { get; set; }
        public decimal FixedAmount { get; set; }

        public Discount() { }
    }
}
