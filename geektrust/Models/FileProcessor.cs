using System;
using System.Collections.Generic;
using System.Text;

namespace geektrust.Models
{
    public class FileProcessor : ICommandProcessor
    {
        public String FilePath { get; }

        public bool FamilyTreeBuilder { get; }

        public FileProcessor(String filePath, bool familyTreeBuilder)
        {
            this.FilePath = filePath;
            this.FamilyTreeBuilder = familyTreeBuilder;
        }

        public void ProcessCommands(Family f)
        {
            if(f == null)
            {
                Console.WriteLine(Messages.FAMILY_TREE_BUILDER_ERROR);
                return;
            }
            try
            {
                string[] lines = System.IO.File.ReadAllLines(this.FilePath);
                foreach (string line in lines)
                {
                    ProcessCommand(f, line);
                }
            }
            catch(Exception)
            {
                Console.WriteLine(Messages.INVALID_FILE);
            }
        }

        private void ProcessCommand(Family f, String command)
        {
            String[] commandParams = FamilyTreeBuilder ? command.Split(";") : command.Split(" ");
            switch (commandParams[0])
            {
                case Commands.ADD_HEAD:
                    if (commandParams.Length == 3)
                        f.AddHead(commandParams[1], commandParams[2]);
                    else
                        Console.WriteLine(Messages.INVALID_COMMAND);
                    break;

                case Commands.ADD_SPOUSE:
                    if (commandParams.Length == 4)
                        f.AddSpouse(commandParams[1], commandParams[2], commandParams[3]);
                    else
                        Console.WriteLine(Messages.INVALID_COMMAND);
                    break;

                case Commands.ADD_CHILD:
                    if (commandParams.Length == 4)
                    {
                        string s = f.AddChild(commandParams[1], commandParams[2], commandParams[3]);
                        if (!FamilyTreeBuilder)
                            Console.WriteLine(s);
                    }
                    else
                        Console.WriteLine(Messages.INVALID_COMMAND);
                    break;

                case Commands.GET_RELATIONSHIP:
                    if (commandParams.Length == 3)
                        f.GetRelation(commandParams[1], commandParams[2]);
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
