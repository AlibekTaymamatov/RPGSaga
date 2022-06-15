namespace RpgSagaLib
{
    using System;

    public class Logger : ILogger
    {
        public Logger()
        {
        }

        public void Log(string value)
        {
            Console.WriteLine(value);
        }
    }
}
