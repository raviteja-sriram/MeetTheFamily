using Microsoft.VisualStudio.TestTools.UnitTesting;
using geektrust.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace geektrust.Models.Tests
{
    [TestClass()]
    public class PersonTests
    {
        Person p;

        [TestInitialize()]
        public void PersonTest()
        {
            p = new Person("P1", Gender.Female, null, null);
        }

        [TestMethod()]
        public void BearChildWithNullValue()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                p.BearChild(null);
                string expected = string.Format("{0}{1}", Messages.CHILD_ADDITION_FAILED, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod()]
        public void BearChildWithNoSpouse()
        {
            Person c1 = new Person("C1", Gender.Female, null, p);
            p.BearChild(c1);
            Assert.AreEqual<Person>(p.Children[0], c1);
            p.Children.Remove(c1);
        }

        [TestMethod()]
        public void MarryWithNullValue()
        {
            p.Marry(null);
            Assert.AreEqual<Person>(p.Spouse, null);
        }

        [TestMethod()]
        public void MarrySuccess()
        {
            Person sp = new Person("sp", Gender.Male, null, null);
            p.Marry(sp);
            Assert.AreEqual<Person>(p.Spouse, sp);
        }

        [TestMethod()]
        public void BearChildWithSpouse()
        {
            Person c1 = new Person("C1", Gender.Female, null, p);
            Person sp = new Person("sp", Gender.Male, null, null);
            p.Marry(sp);
            p.BearChild(c1);
            Assert.AreEqual<Person>(p.Children[0], c1);
            Assert.AreEqual<Person>(p.Spouse.Children[0], c1);
        }
    }
}