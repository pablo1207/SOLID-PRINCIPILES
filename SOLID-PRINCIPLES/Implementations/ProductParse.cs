

using SOLID_PRINCIPLES.interfaces;
using SOLID_PRINCIPLES.Models;

namespace SOLID_PRINCIPLES.Implementations
{
    public class ProductParse: IProductParse
    {
        private readonly IProductValidator _validator;
        private readonly IProductMapper _mapper;

        public ProductParse(IProductValidator validator, IProductMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public IEnumerable<Product> parseProducts(IEnumerable<string> productsData) 
        {

            var products = new List<Product>();
            var lineCount = 1;
            foreach (var line in productsData)
            {
                var fields = line.Split('|');

                if (!_validator.ValidateProductData(fields))
                {
                    continue;
                }

                Product product = _mapper.MapProductDataToProductRecord(fields);

                products.Add(product);
                lineCount++;
            }

            return products;
        }
    }
}
