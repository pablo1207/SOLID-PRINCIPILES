using SOLID_PRINCIPLES.interfaces;

namespace SOLID_PRINCIPLES.Implementations
{
    public class ProductDataProvider: IProductDataProvider
    {
        public IEnumerable<string> ReadProductsData(Stream stream)
        {
            var lines = new List<string>();

            // Read to file 
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}
