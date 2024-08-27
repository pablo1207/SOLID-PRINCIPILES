using SOLID_PRINCIPLES.interfaces;
using SOLID_PRINCIPLES.Models;

namespace SOLID_PRINCIPLES.Implementations
{
    public class ProductProcessor
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly IProductParse _productParse;
        private readonly IProductStorage _productStorage;
        string productPath;

        public ProductProcessor(IProductDataProvider productDataProvider, IProductParse productParse, IProductStorage productStorage)
        {
            _productDataProvider = productDataProvider;
            _productParse = productParse;
            _productStorage = productStorage;
        }

        public void ProcessProducts(Stream stream)
        {
            // Read to file 
            var lines = _productDataProvider.ReadProductsData(stream);
            var products = _productParse.parseProducts(lines);
            _productStorage.StoreProducts(products);
        }
    }
}
