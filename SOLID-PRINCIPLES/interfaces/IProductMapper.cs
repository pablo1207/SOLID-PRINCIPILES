using SOLID_PRINCIPLES.Models;

namespace SOLID_PRINCIPLES.interfaces
{
    public interface IProductMapper
    {
        Product MapProductDataToProductRecord(string[] fields);
    }
}
