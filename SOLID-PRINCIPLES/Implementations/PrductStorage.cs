using SOLID_PRINCIPLES.interfaces;
using SOLID_PRINCIPLES.Models;
using System.IO;

namespace SOLID_PRINCIPLES.Implementations
{
    public class PrductStorage: IProductStorage
    {
        private readonly string _productPath;
        private readonly ILogger _logger;

        public PrductStorage(string productPath, ILogger logger)
        {
            _productPath = productPath;
            _logger = logger;
        }

        public void StoreProducts(IEnumerable<Product> products)
        {
            //Save in txt
            var linesToPrint = new List<string>();
            linesToPrint.Add("Código\tClave\tDescripción\t\t\tCant.\tPrecio\tImporte\tIVA\tIEPS");
            foreach (var product in products)
            {
                linesToPrint.Add(
                    product.Code + "\t" +
                    product.Classification + "\t" +
                    product.Description + "\t" +
                    product.Quantity + "\t" +
                    product.UnitPrice + "\t" +
                    product.Amount + "\t" +
                    product.IVA + "\t" +
                product.IEPS);
            }

            System.IO.File.WriteAllLines(_productPath, linesToPrint);

            _logger.Info(string.Format("INFO: {0} Productos procesados.", products.Count()));
        }
    }
}
