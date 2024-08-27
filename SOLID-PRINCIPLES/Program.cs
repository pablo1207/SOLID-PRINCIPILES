using SOLID_PRINCIPLES;
using SOLID_PRINCIPLES.Implementations;
using SOLID_PRINCIPLES.interfaces;
using System.Text;

class Program
{

    static void Main(string[] args)
    {
        ILogger logger = new Logger();
        IProductDataProvider productDataProvider = new ProductDataProvider();

        IProductValidator productValidator = new ProductValidator(logger);
        IProductMapper productMapper = new ProductMapper();
        IProductParse productParse = new ProductParse(productValidator, productMapper);

        var path = Directory.GetCurrentDirectory() + "\\reporte.txt";
        IProductStorage productStorage = new PrductStorage(path, logger);


        var productProcesor = new ProductProcessor(productDataProvider, productParse, productStorage);

        MemoryStream stream = GetMemoryStremProducts();
        productProcesor.ProcessProducts(stream);

        Console.WriteLine("El archivo se creó exitosamente.");
        Console.ReadLine();

    }

    private static MemoryStream GetMemoryStremProducts()
    {
        string productsString = "AAA0045|T1  |cacahuates japoneses 150gr  |1 |15.00  \n" +
                                "AAA0037|T3  |cerveza  minerva 355ml      |1 |30.00  \n" +
                                "AAA0014|A1  |Jabon Ariel 800gr           |1 |32.80  \n" +
                                "AAA0234|A4  |Papel Higienico petalo 12   |1 |60.00  \n" +
                                "AAA0110|B0  |Pasta de dientes 150ml      |1 |43.50  \n" +
                                "AAA0001|T2  |Coca cola 2.5 ltrs          |1 |25.00  \n" +
                                "AAA0022|T1  |Sabritas naturales 100gr    |2 |20.00  \n" +
                                "AAA0045|T2  |Sprite2.5 ltrs              |1 |23.00  ";


        // convert string to stream
        byte[] byteArray = Encoding.ASCII.GetBytes(productsString);
        MemoryStream stream = new MemoryStream(byteArray);
        return stream;
    }
}