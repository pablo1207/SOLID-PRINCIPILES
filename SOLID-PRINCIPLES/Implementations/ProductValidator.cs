using SOLID_PRINCIPLES.interfaces;

namespace SOLID_PRINCIPLES.Implementations
{
    public class ProductValidator: IProductValidator
    {
        private readonly ILogger _logger;
        public ProductValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool ValidateProductData(string[] fields)
        {
            if (fields.Length != 5)
            {
                _logger.Info("La estructura del archivo de productos es inválida.");
                return false;
            }

            int quantity = 0;
            if (!Int32.TryParse(fields[3], out quantity))
            {
                _logger.Info("La cantidad del producto es inválida.");
                return false;
            }

            decimal unitPrice = 0;
            if (!decimal.TryParse(fields[4], out unitPrice))
            {
                _logger.Info("El precio unitario del producto es inválido.");
                return false;
            }

            return true;
        }

    }
}
