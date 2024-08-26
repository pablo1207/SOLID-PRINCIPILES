namespace SOLID_PRINCIPLES
{
    public class ProductProcessor
    {
        string productPath;

        public ProductProcessor(string path)
        {
            productPath = path;
        }

        public void ProcessProducts(System.IO.Stream stream)
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
            var products = new List<Product>();
            var lineCount = 1;

            foreach (var line in lines)
            {
                var fields = line.Split('|');
                if (fields.Length != 5)
                {
                    Console.WriteLine("La estructura del archivo de producto es inválida.");
                    continue;
                }

                int quantity = 0;
                if (!Int32.TryParse(fields[3], out quantity))
                {
                    Console.WriteLine("La cantidad del procuto es inválida");
                    continue;
                }

                decimal unitPrice = 0;

                if (!Decimal.TryParse(fields[4], out unitPrice))
                {
                    Console.WriteLine("El precio unitario del producto es inválido");
                    continue;
                }

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
                    IEPS = ieps,
                    IVA = iva
                };

                products.Add(product);
                lineCount++;


                // Save in txt
                var linesToPrint = new List<string>();
                linesToPrint.Add("Código\tClave\tDescription\t\t\tCant.\tPrecio\tImporte\tIVA\tIEPS");

                foreach (var data in products)
                {
                    linesToPrint.Add(
                        data.Code + "\t" +
                        data.Classification + "\t" +
                        data.Description + "\t" +
                        data.Quantity + "\t" +
                        data.UnitPrice + "\t" +
                        data.Amount + "\t" +
                        data.IVA + "\t" +
                        data.IEPS
                        );
                }

                System.IO.File.WriteAllLines(productPath, linesToPrint);
            }
            Console.WriteLine("INFO: {0} Productos procesados.", products.Count);
        }
    }
}
