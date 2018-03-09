using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _01_PARSER_Test_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0. Size of the project array - 16*16
            // 1. Seed a random array
            // 2. Write the seed into SeedMap.txt

            // set parameters
            // string seedPath = @"..\data\SeedMap.txt";
            // int mapSize = 16;
            // string logPath = @"..\data\WorkLog.txt";
            
            List<int> layerTempArray = new List<int>();

            ClearLog();
            ClearSeedFile();
            UpdateLog("Seed file and Log file reset");
            
            // 1. Seed a random array
            Random buzzer = new Random();
            int[] seedArray = new int[Globals.mapSize * Globals.mapSize];

            for (int ii = 0; ii < seedArray.Length-1; ii++)
            {
                seedArray[ii] = buzzer.Next(0, 256);
            }

            // Write the array into SeedMap.txt
            string seedArrayString = string.Join("|" , seedArray);
            System.IO.File.WriteAllText(Globals.seedPath, seedArrayString);

            // Note Down in WorkLog.txt
            UpdateLog("ReSeed");
            UpdateLog("Seed -> SeedMap.txt");

            // Read and Parse the SeedFile
            string incomingStringArray = File.ReadAllText(Globals.seedPath);
            layerTempArray = incomingStringArray.Split(new char[] { '|' }).Select(v => int.Parse(v)).ToList();
            UpdateLog("SeedMap.txt -> Map");

            // Control Output
            DisplayMap(layerTempArray, Globals.mapSize);
            UpdateLog("TEST PRINT");
        }

        private static void DisplayMap(List<int> layerTempArray, int mapSize)
        {
            int counter = 0;
            foreach (var cell in layerTempArray)
            {
                int intValue = (int)cell;
                Console.Write($"[{intValue:d3}]");
                if ((counter+1) % mapSize == 0)
                {
                    Console.WriteLine();
                }
                counter++;
            }
        }

        private static void ClearSeedFile()
        {
            System.IO.File.Delete(Globals.seedPath);
        }

        private static void ClearLog()
        {
            System.IO.File.Delete(Globals.seedPath);
        }

        private static void UpdateLog(string logMessage)
        {
            logMessage = $"[{DateTime.Now}] {logMessage} {Environment.NewLine}";
            System.IO.File.AppendAllText(Globals.logPath, logMessage);
        }
    }
}
