using SOLID_PRINCIPLES.Models;

namespace SOLID_PRINCIPLES.interfaces
{
    public interface IProductStorage
    {
        void StoreProducts(IEnumerable<Product> products);
    }
}
