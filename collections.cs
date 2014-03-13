using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace collections
{
    class Collections
    {
        static void Main(string[] args)
        {
            List<string> theBigList = new List<string>();
            foreach (string directory in Directory.GetDirectories(@"C:/"))
            {
                theBigList.Add(directory);

            }
            theBigList.Sort();

            foreach (var entry in theBigList)
            {
                Console.WriteLine(entry);
            }
            Console.ReadLine();
        }

    }
}
