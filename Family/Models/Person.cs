using System;
using System.Collections.Generic;
using System.Text;

namespace geektrust.Models
{
    public class Person
    {
        public String Name { get; set; }
        public Gender PersonGender { get; set; }
        public Person Mother { get; set; }
        public Person Father { get; set; }
        public List<Person> Children { get; set; }
        public Person Spouse { get; set; }

        public Person(String name, Gender gender, Person mother, Person father)
        {
            this.Name = name;
            this.PersonGender = gender;
            this.Mother = mother;
            this.Father = father;
            this.Children = new List<Person>();
        }

        public void AddChild(Person child)
        {
            this.Children.Add(child);
            if (this.Spouse != null)
            {
                this.Spouse.Children.Add(child);
            }
        }

        public void AddSpouse(Person spouse)
        {
            this.Spouse = spouse;
        }

    }
}
