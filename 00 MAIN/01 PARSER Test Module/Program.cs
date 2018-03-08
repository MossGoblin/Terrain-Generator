using System;
using System.IO;
using System.Text;

namespace _01_PARSER_Test_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string logMessage = "";
            // 0. Size of the project array - 32*32
            // 1. Seed a random array
            // 2. Write the seed into SeedMap.txt

            // 1. Seed a random array
            Random buzzer = new Random();
            int[] seedArray = new int[1024];

            for (int ii = 0; ii < seedArray.Length-1; ii++)
            {
                int newRND = buzzer.Next(0, 256);
                seedArray[ii] = newRND;
            }

            // Write the array into SeedMap.txt
            string seedArrayString = string.Join("|" , seedArray);
            System.IO.File.WriteAllText(@"..\data\SeedMap.txt", seedArrayString);

            // Note Down in WorkLog.txt

            logMessage = $"[{DateTime.Now}] ReSeed {Environment.NewLine}";
            System.IO.File.AppendAllText(@"..\data\WorkLog.txt", logMessage);
            logMessage = $"[{DateTime.Now}] Seed -> SeedMap.txt {Environment.NewLine}";
            System.IO.File.AppendAllText(@"..\data\WorkLog.txt", logMessage);

            Console.WriteLine();
        }
    }
}
