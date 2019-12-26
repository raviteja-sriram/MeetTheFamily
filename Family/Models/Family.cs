using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geektrust.Models
{
    public class Family
    {
        public Dictionary<string, Person> familyMembers;
        public Family()
        {
            familyMembers = new Dictionary<string, Person>();
            ConstructFamilyTree();
        }

        private Person CreatePerson(String name, Gender gender, String mother, String father)
        {
            Person m = mother != null ? familyMembers[mother] : null, f = father != null ? familyMembers[father] : null;
            Person newPerson = new Person(name, gender, m, f);
            familyMembers.Add(name, newPerson);
            return newPerson;
        }

        public String AddChild(String motherName, String childName, string gender)
        {
            if (familyMembers.ContainsKey(childName))
            {
                return Messages.DULPLICATE_PERSON_ERROR;
            }
            Person mother = GetPerson(motherName);
            if(mother == null)
            {
                return Messages.PERSON_NOT_FOUND;
            }
            else if(childName == null || gender == null || mother.PersonGender == Gender.Male || !Enum.GetNames(typeof(Gender)).Contains(gender))
            {
                return Messages.CHILD_ADDITION_FAILED;
            }
            else
            {
                Gender g = gender.Equals("Male") ? Gender.Male : Gender.Female;
                mother.AddChild(CreatePerson(childName, g, motherName, mother.Spouse != null ? mother.Spouse.Name : null));
                return Messages.CHILD_ADDITION_SUCCEEDED;
            }
        }

        private void AddSpouse(string spouseName, string personName, string gender)
        {
            Person spouse = GetPerson(spouseName);
            if (spouse != null && spouse.Spouse == null)
            {
                Gender g = gender.Equals("Male") ? Gender.Male : Gender.Female;
                Person p = CreatePerson(personName, g, null, null);
                p.AddSpouse(spouse);
                spouse.AddSpouse(p);
            }
        }

        private Person GetPerson(String name)
        {
            if(name != null && familyMembers.ContainsKey(name))
            {
                return familyMembers[name];
            }
            return null;
        }

        private void ConstructFamilyTree()
        {
            Person king = CreatePerson("King Shan", Gender.Male, null, null);
            AddSpouse("King Shan", "Queen Anga", "Female");

            AddChild("Queen Anga", "Chit", "Male");
            AddChild("Queen Anga", "Ish", "Male");
            AddChild("Queen Anga", "Vich", "Male");
            AddChild("Queen Anga", "Aras", "Male");
            AddChild("Queen Anga", "Satya", "Female");

            AddSpouse("Chit", "Amba", "Female");
            AddSpouse("Vich", "Lika", "Female");
            AddSpouse("Aras", "Chitra", "Female");
            AddSpouse("Satya", "Vyan", "Male");

            AddChild("Amba", "Dritha", "Female");
            AddChild("Amba", "Tritha", "Female");
            AddChild("Amba", "Vritha", "Male");

            AddChild("Lika", "Vila", "Female");
            AddChild("Lika", "Chika", "Female");

            AddChild("Chitra", "Jnki", "Female");
            AddChild("Chitra", "Ahit", "Male");

            AddChild("Satya", "Asva", "Male");
            AddChild("Satya", "Vyas", "Male");
            AddChild("Satya", "Atya", "Female");

            AddSpouse("Dritha", "Jaya", "Male");
            AddSpouse("Jnki", "Arit", "Male");
            AddSpouse("Asva", "Satvy", "Female");
            AddSpouse("Vyas", "Krpi", "Female");

            AddChild("Dritha", "Yodhan", "Male");
            AddChild("Jnki", "Laki", "Male");
            AddChild("Jnki", "Lavnya", "Female");
            AddChild("Satvy", "Vasa", "Male");
            AddChild("Krpi", "Kriya", "Male");
            AddChild("Krpi", "Krithi", "Female");
        }
    }
}
