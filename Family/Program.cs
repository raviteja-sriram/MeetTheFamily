using geektrust.Models;
using System;

namespace geektrust
{
    class Program
    {
        static void Main(string[] args)
        {
            Family kingShanFamily = new Family();
            Relationships relations = new Relationships();
            if(args.Length < 1)
            {
                Console.WriteLine("Mention the input file path");
                return;
            }
            String filePath = args[0];
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                ProcessCommand(kingShanFamily, relations, line);
            }
        }

        private static void ProcessCommand(Family kingShanFamily, Relationships relations, string command)
        {
            String[] commandParams = command.Split(" ");
            switch (commandParams[0])
            {
                case Commands.ADD_CHILD:
                    if (commandParams.Length == 4)
                        Console.WriteLine(kingShanFamily.AddChild(commandParams[1], commandParams[2], commandParams[3]));
                    else
                        Console.WriteLine(Messages.INVALID_COMMAND);
                    break;

                case Commands.GET_RELATIONSHIP:
                    if(commandParams.Length == 3)
                        relations.GetRelation(kingShanFamily.familyMembers, commandParams[1], commandParams[2]);
                    else
                        Console.WriteLine(Messages.INVALID_COMMAND);
                    break;

                default:
                    Console.WriteLine(Messages.INVALID_COMMAND);
                    break;
            }
        }
    }
}
