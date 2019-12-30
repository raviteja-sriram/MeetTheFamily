using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geektrust.Models
{
    public class Family
    {
        public Dictionary<string, Person> familyMembers;

        public Family(String filePath)
        {
            familyMembers = new Dictionary<string, Person>();
            FileProcessor f = new FileProcessor(filePath, true);
            f.ProcessCommands(this);
        }

        public void GetRelation(String personName, String relation)
        {
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                Console.WriteLine(Messages.PERSON_NOT_FOUND);
            }
            else if (relation == null || !familyMembers[personName].Relationships.ContainsKey(relation))
            {
                Console.WriteLine(Messages.INVALID_COMMAND);
            }
            else
            {
                String[] maleRelations = { Relations.Son, Relations.Maternal_Uncle, Relations.Paternal_Uncle, Relations.Brother_In_Law };
                familyMembers[personName].Relationships[relation](maleRelations.Contains(relation) ? Gender.Male : Gender.Female, familyMembers);
            }
        }

        public String AddChild(String motherName, String childName, string gender)
        {
            if (childName != null && familyMembers.ContainsKey(childName))
            {
                return Messages.DULPLICATE_PERSON_ERROR;
            }
            Person mother = GetPerson(motherName);
            if (mother == null)
            {
                return Messages.PERSON_NOT_FOUND;
            }
            else if (childName == null || gender == null || mother.PersonGender == Gender.Male || !Enum.GetNames(typeof(Gender)).Contains(gender))
            {
                return Messages.CHILD_ADDITION_FAILED;
            }
            else
            {
                Gender g = gender.Equals("Male") ? Gender.Male : Gender.Female;
                mother.BearChild(CreatePerson(childName, g, motherName, mother.Spouse != null ? mother.Spouse.Name : null));
                return Messages.CHILD_ADDITION_SUCCEEDED;
            }
        }

        public void AddHead(String headName, String gender)
        {
            if (this.familyMembers.Count > 0)
            {
                Console.WriteLine("Family head is already existing.");
            }
            else
            {
                Gender g = gender.Equals("Male") ? Gender.Male : Gender.Female;
                this.CreatePerson(headName, g, null, null);
            }
        }

        public void AddSpouse(string spouseName, string personName, string gender)
        {
            Person spouse = GetPerson(spouseName);
            if (spouse != null && spouse.Spouse == null)
            {
                Gender g = gender.Equals("Male") ? Gender.Male : Gender.Female;
                Person p = CreatePerson(personName, g, null, null);
                p.Marry(spouse);
                spouse.Marry(p);
            }
        }

        private Person GetPerson(String name)
        {
            if (name != null && familyMembers.ContainsKey(name))
            {
                return familyMembers[name];
            }
            return null;
        }

        private Person CreatePerson(String name, Gender gender, String mother, String father)
        {
            Person m = mother != null ? familyMembers[mother] : null, f = father != null ? familyMembers[father] : null;
            Person newPerson = new Person(name, gender, m, f);
            familyMembers.Add(name, newPerson);
            return newPerson;
        }
    }
}
