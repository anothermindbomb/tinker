using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tinker
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:/trimtest\AllNonStringFields/trimtest.txt";
            string lineOfData;
            using (var inputFile = new StreamReader(filename, true))
            {
                lineOfData = inputFile.ReadLine();
                while (lineOfData != null)
                {
                    // Console.WriteLine(lineOfData);
                    lineOfData = inputFile.ReadLine();
                }
            }

        }
    }
}
