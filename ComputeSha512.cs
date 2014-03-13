using System;
using System.IO;
using System.Security.Cryptography;

namespace Tinker
{
    class ComputeSha512
    {
        static void Main(string[] args)
        {
            DirSearch(@"C:/");
            Console.ReadLine();

        }

        static void DirSearch(string startDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(startDir))
                {
                    computeSHA512(d);
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        static void computeSHA512(string directory)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            // Get the FileInfo objects for every file in the directory.
            FileInfo[] files = dir.GetFiles();
            SHA512 mySHA512 = SHA512Managed.Create();
            byte[] hashValue;
            // Compute and print the hash values for each file in directory.
            foreach (FileInfo fInfo in files)
            {
                // Create a fileStream for the file.
                FileStream fileStream = fInfo.Open(FileMode.Open);
                // Be sure it's positioned to the beginning of the stream.
                fileStream.Position = 0;
                // Compute the hash of the fileStream.
                hashValue = mySHA512.ComputeHash(fileStream);
                // Write the name of the file to the Console.
                Console.Write(fInfo.Name + ": ");
                // Write the hash value to the Console.
                PrintByteArray(hashValue);
                // Close the file.
                fileStream.Close();
            }
        }

        public static void PrintByteArray(byte[] array)
        {
            int i;
            for (i = 0; i < array.Length; i++)
            {
                Console.Write(String.Format("{0:X2}", array[i]));
                if ((i % 4) == 3) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
