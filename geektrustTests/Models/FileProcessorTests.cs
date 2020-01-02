using Microsoft.VisualStudio.TestTools.UnitTesting;
using geektrust.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace geektrust.Models.Tests
{
    [TestClass()]
    public class FileProcessorTests
    {
        FileProcessor f;
        Family family;

        [TestInitialize()]
        public void FileProcessorTest()
        {
            f = new FileProcessor(@"../../../../geektrust/FamilyTreeConstructor.txt", true);
            family = new Family(@"../../../../geektrust/FamilyTreeConstructor.txt");
        }

        [TestMethod()]
        public void FileProcessorWithNullFileName()
        {
            f = new FileProcessor(null, true);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.ProcessCommands(family);
                string expected = string.Format("{0}{1}", Messages.INVALID_FILE, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod()]
        public void FileProcessorWithNullFamily()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.ProcessCommands(null);
                string expected = string.Format("{0}{1}", Messages.FAMILY_TREE_BUILDER_ERROR, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod()]
        public void FileProcessorWithInvalidCommand()
        {
            f = new FileProcessor(@"../../../../geektrust/Test1.txt", false);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.ProcessCommands(family);
                string expected = string.Format("{0}{1}", Messages.INVALID_COMMAND, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod()]
        public void FileProcessorWithValidCommand()
        {
            f = new FileProcessor(@"../../../../geektrust/Test.txt", false);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.ProcessCommands(family);
                string expected = string.Format("{0}{1}", Messages.CHILD_ADDITION_SUCCEEDED, Environment.NewLine);
                expected += string.Format("{0}{1}", "Asva Ketu", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}