using SOLID_PRINCIPLES.interfaces;
using SOLID_PRINCIPLES.Models;

namespace SOLID_PRINCIPLES.Implementations
{
    public class ProductMapper: IProductMapper
    {
        public Product MapProductDataToProductRecord(string[] fields)
        {
            var quantity = int.Parse(fields[3]);
            var unitPrice = decimal.Parse(fields[4]);
            decimal amount = unitPrice * quantity;
            decimal iva = amount * (decimal)0.16;
            decimal ieps = 0;
            if (fields[1].StartsWith("T"))
            {
                ieps = amount * (decimal)0.30;
            }

            var product = new Product()
            {
                Code = fields[0],
                Classification = fields[1],
                Description = fields[2],
                Quantity = quantity,
                UnitPrice = unitPrice,
                Amount = amount,
                IVA = iva,
                IEPS = ieps,
            };
            return product;
        }
    }
}
