using SOLID_PRINCIPLES.Models;

namespace SOLID_PRINCIPLES.interfaces
{
    public interface IProductParse
    {
        IEnumerable<Product> parseProducts(IEnumerable<string> productsData);
    }
}
