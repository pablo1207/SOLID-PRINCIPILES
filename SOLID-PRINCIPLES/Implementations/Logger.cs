using SOLID_PRINCIPLES.interfaces;

namespace SOLID_PRINCIPLES.Implementations
{
    public class Logger : ILogger
    {

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

    }
}
