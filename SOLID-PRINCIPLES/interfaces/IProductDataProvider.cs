namespace SOLID_PRINCIPLES.interfaces
{
    public interface IProductDataProvider
    {
        IEnumerable<string> ReadProductsData(Stream stream);
    }
}
