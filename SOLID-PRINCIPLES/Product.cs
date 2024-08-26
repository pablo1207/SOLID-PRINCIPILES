namespace SOLID_PRINCIPLES
{
    public class Product
    {
        public string Code { get; set; }

        public string Classification { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public decimal IVA { get; set; }

        public decimal IEPS { get; set; }
    }
}
