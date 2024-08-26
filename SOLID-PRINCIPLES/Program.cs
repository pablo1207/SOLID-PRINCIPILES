using SOLID_PRINCIPLES;
using System.Text;

class Program
{

    static void Main(string[] args)
    {
        var productProcessor = new ProductProcessor(Directory.GetCurrentDirectory() + "\\reporte.txt");
        MemoryStream stream = getMemoryStreamProducts();
        productProcessor.ProcessProducts(stream);

        Console.WriteLine("El archivo se creo existosamente");
        Console.ReadLine();

    }

    private static MemoryStream getMemoryStreamProducts()
    {
        string productString =
            "AAA0045|T1 |cacahuates japoneses 150gr |1 |15.00  \n" +
            "AAA0046|T3 |cacahuates japoneses 150gr |2 |15.00  \n" +
            "AAA0047|A1 |cacahuates japoneses 150gr |4 |15.00  \n" +
            "AAA0048|A4 |cacahuates japoneses 150gr |5 |15.00  \n" +
            "AAA0049|B0 |cacahuates japoneses 150gr |1 |15.00  ";

        // convert string to stream
        byte[] byteArray = Encoding.ASCII.GetBytes(productString);
        MemoryStream stream = new MemoryStream(byteArray);
        return stream;
    }
}