using geektrust.Models;
using System;

namespace geektrust
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("Mention the input file path");
                return;
            }

            //This constructor will initialize the family tree from text file provided.
            Family kingShanFamily = new Family(@"FamilyTreeConstructor.txt");

            String filePath = args[0];
            FileProcessor f = new FileProcessor(filePath, false);
            f.ProcessCommands(kingShanFamily);
        }
    }
}
