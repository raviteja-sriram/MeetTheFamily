using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geektrust.Models
{
    public class Person
    {
        public String Name { get; }
        public Gender PersonGender { get; }
        public Person Mother { get; }
        public Person Father { get; }
        public List<Person> Children { get; }
        public Person Spouse { get; set; }

        public Dictionary<String, Action<Gender, IDictionary<String, Person>>> Relationships = new Dictionary<string, Action<Gender, IDictionary<string, Person>>>();
        
        public Person(String name, Gender gender, Person mother, Person father)
        {
            this.Name = name;
            this.PersonGender = gender;
            this.Mother = mother;
            this.Father = father;
            this.Children = new List<Person>();
            InitRelationships();
        }

        public void BearChild(Person child)
        {
            this.Children.Add(child);
            if (this.Spouse != null)
            {
                this.Spouse.Children.Add(child);
            }
        }

        public void Marry(Person spouse)
        {
            this.Spouse = spouse;
        }

        public void InitRelationships()
        {
            Relationships.Add(Relations.Son, GetSonOrDaughters);
            Relationships.Add(Relations.Daughter, GetSonOrDaughters);
            Relationships.Add(Relations.Siblings, GetSiblings);
            Relationships.Add(Relations.Paternal_Uncle, GetPaternalUncleOrAunts);
            Relationships.Add(Relations.Maternal_Uncle, GetMaternalUncleOrAunts);
            Relationships.Add(Relations.Paternal_Aunt, GetPaternalUncleOrAunts);
            Relationships.Add(Relations.Maternal_Aunt, GetMaternalUncleOrAunts);
            Relationships.Add(Relations.Sister_In_Law, GetBrotherOrSisterInLaws);
            Relationships.Add(Relations.Brother_In_Law, GetBrotherOrSisterInLaws);
        }

        private void GetPaternalUncleOrAunts(Gender g, IDictionary<string, Person> familyMembers)
        {
            StringBuilder paternalUncles = new StringBuilder();
            if (this.Father != null && this.Father.Mother != null)
            {
                foreach (Person p in this.Father.Mother.Children)
                {
                    if (p.PersonGender == g && p.Name != this.Father.Name)
                        paternalUncles.Append(p.Name).Append(" ");
                }
            }
            PrintToConsole(paternalUncles);
        }

        private void GetMaternalUncleOrAunts(Gender g, IDictionary<string, Person> familyMembers)
        {
            StringBuilder maternalUncles = new StringBuilder();
            if (this.Mother != null && this.Mother.Mother != null)
            {
                foreach (Person p in this.Mother.Mother.Children)
                {
                    if (p.PersonGender == g && p.Name != this.Mother.Name)
                        maternalUncles.Append(p.Name).Append(" ");
                }
            }
            PrintToConsole(maternalUncles);
        }

        private void GetBrotherOrSisterInLaws(Gender g, IDictionary<string, Person> familyMembers)
        {
            StringBuilder inLaws = new StringBuilder();
            if (this.Mother != null)
            {
                foreach (Person p in this.Mother.Children)
                {
                    if (p.Name != this.Name && p.Spouse != null && p.Spouse.PersonGender == g)
                        inLaws.Append(p.Spouse.Name).Append(" ");
                }
            }
            if (this.Spouse != null && this.Spouse.Mother != null)
            {
                foreach (Person p in this.Spouse.Mother.Children)
                {
                    if (p.Name != this.Spouse.Name && p.PersonGender == g)
                        inLaws.Append(p.Name).Append(" ");
                }
            }
            PrintToConsole(inLaws);
        }

        private void GetSiblings(Gender g, IDictionary<string, Person> familyMembers)
        {
            StringBuilder siblings = new StringBuilder();
            foreach (Person p in this.Mother.Children)
            {
                if (p.Name != this.Name)
                    siblings.Append(p.Name).Append(" ");
            }
            PrintToConsole(siblings);
        }

        private void GetSonOrDaughters(Gender g, IDictionary<string, Person> familyMembers)
        {
            StringBuilder daughters = new StringBuilder();
            foreach (Person p in this.Children)
            {
                if (p.PersonGender == g)
                {
                    daughters.Append(p.Name).Append(" ");
                }
            }
            PrintToConsole(daughters);
        }

        private void PrintToConsole(StringBuilder sb)
        {
            Console.WriteLine(String.IsNullOrEmpty(sb.ToString().Trim()) ? Messages.NONE : sb.ToString().Trim());
        }

    }
}
