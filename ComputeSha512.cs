using System;
using System.IO;
using System.Security.Cryptography;

namespace Tinker
{
    class ComputeSha512
    {
        static void Main(string[] args)
        {
            DirSearch(@"C:/Windows");
            Console.WriteLine("Done. Hit Enter to close this window");
            Console.ReadLine();

        }

        static void DirSearch(string startDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(startDir))
                {
                    computeSHA(d);
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        static void computeSHA(string directory)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            // Get the FileInfo objects for every file in the directory.
            FileInfo[] files = dir.GetFiles();
            SHA1 mySHA = SHA1Managed.Create();
            byte[] hashValue;
            // Compute and print the hash values for each file in directory.
            foreach (FileInfo fInfo in files)
            {
                FileStream fileStream = fInfo.Open(FileMode.Open);
                // Be sure the filestream is positioned to the beginning of the stream.
                fileStream.Position = 0;
                // Compute the hash of the fileStream - it's a byte array so we need to decode it to print it
                // correctly.
                hashValue = mySHA.ComputeHash(fileStream);
                Console.Write(fInfo.Name + ": ");
                PrintByteArray(hashValue);
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
