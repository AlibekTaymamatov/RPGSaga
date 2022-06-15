namespace RpgSagaLib.InputOutput
{
    using System;
    using System.IO;

    public class FileIO : IReader
    {
        private StreamReader file;

        public FileIO(string patch)
        {
            if (File.Exists(patch))
            {
                file = new StreamReader(patch);
            }
            else
            {
                throw new Exception();
            }
        }

        public string ReadLine()
        {
            return file.ReadLine() ?? string.Empty;
        }
    }
}
