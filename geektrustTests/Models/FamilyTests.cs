using Microsoft.VisualStudio.TestTools.UnitTesting;
using geektrust.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace geektrust.Models.Tests
{
    [TestClass()]
    public class FamilyTests
    {
        private Family f;

        [TestInitialize()]
        public void FamilyTest()
        {
            f = new Family(@"../../../../geektrust/FamilyTreeConstructor.txt");
        }

        [TestMethod()]
        public void AddChildWithNullValues()
        {
            //Providing mother value as null
            StringAssert.Contains(Messages.PERSON_NOT_FOUND, f.AddChild(null, "C1", "Male"));

            //Providing child value as null
            StringAssert.Contains(Messages.CHILD_ADDITION_FAILED, f.AddChild("Chitra", null, "Female"));
        }

        [TestMethod()]
        public void AddChildWithGenderNullValues()
        {
            //Providing gender as null
            StringAssert.Contains(Messages.CHILD_ADDITION_FAILED, f.AddChild("Chitra", "C1", null));
        }

        [TestMethod()]
        public void AddChildThroughFather()
        {
            //Adding child to male parent
            StringAssert.Contains(Messages.CHILD_ADDITION_FAILED, f.AddChild("Aras", "C1", "Male"));
        }

        [TestMethod()]
        public void AddChildWithWrogGender()
        {
            StringAssert.Contains(Messages.CHILD_ADDITION_FAILED, f.AddChild("Satya", "C1", "XYZ"));
        }

        [TestMethod()]
        public void AddChildToNonExistingMother()
        {
            StringAssert.Contains(Messages.PERSON_NOT_FOUND, f.AddChild("M1", "C1", "Male"));
        }

        [TestMethod()]
        public void AddChildSuccess()
        {
            StringAssert.Contains(Messages.CHILD_ADDITION_SUCCEEDED, f.AddChild("Satya", "Ketu", "Male"));
        }

        [TestMethod()]
        public void GetRelationshipWithNullValues()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.GetRelation(null, "Son");
                string expected = string.Format("{0}{1}", Messages.PERSON_NOT_FOUND, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod()]
        public void GetRelationshipForNonExistingPerson()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.GetRelation("P1", "Son");
                string expected = string.Format("{0}{1}", Messages.PERSON_NOT_FOUND, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod()]
        public void GetRelationshipWithNonExistingRelation()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.GetRelation("Satya", "R1");
                string expected = string.Format("{0}{1}", Messages.INVALID_COMMAND, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod()]
        [DataRow("Satya", "Paternal-Uncle", "NONE")]
        [DataRow("Asva", "Maternal-Uncle", "Chit Ish Vich Aras")]
        [DataRow("Satvy", "Brother-In-Law", "Vyas")]
        [DataRow("Satya", "Sister-In-Law", "Amba Lika Chitra")]
        [DataRow("Ahit", "Paternal-Aunt", "Satya")]
        [DataRow("Yodhan", "Maternal-Aunt", "Tritha")]
        [DataRow("Aras", "Son", "Ahit")]
        [DataRow("Vich", "Daughter", "Vila Chika")]
        [DataRow("Ish", "Siblings", "Chit Vich Aras Satya")]
        public void GetRelationshipSuccess(String personName, String relationship, string expectedVal)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                f.GetRelation(personName, relationship);
                string expected = string.Format("{0}{1}", expectedVal, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}