using System;
using System.Collections.Generic;
using System.Text;

namespace geektrust.Models
{
    public static class RelationshipsHelper
    {
        public const String Son = "Son";
        public const String Daughter = "Daughter";
        public const String Siblings = "Siblings";
        public const String Paternal_Uncle = "Paternal-Uncle";
        public const String Maternal_Uncle = "Maternal-Uncle";
        public const String Paternal_Aunt = "Paternal-Aunt";
        public const String Maternal_Aunt = "Maternal-Aunt";
        public const String Sister_In_Law = "Sister-In-Law";
        public const String Brother_In_Law = "Brother-In-Law";


        internal static void GetPaternalUncles(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder paternalUncles = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                paternalUncles.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                if (familyMembers[personName].Father != null && familyMembers[personName].Father.Mother != null)
                {
                    foreach (Person p in familyMembers[personName].Father.Mother.Children)
                    {
                        if (p.PersonGender == Gender.Male && p.Name != familyMembers[personName].Father.Name)
                            paternalUncles.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(paternalUncles.ToString().Trim()) ? Messages.NONE : paternalUncles.ToString().Trim());
        }

        internal static void GetMaternalUncles(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder maternalUncles = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                maternalUncles.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                if (familyMembers[personName].Mother != null && familyMembers[personName].Mother.Mother != null)
                {
                    foreach (Person p in familyMembers[personName].Mother.Mother.Children)
                    {
                        if (p.PersonGender == Gender.Male)
                            maternalUncles.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(maternalUncles.ToString().Trim()) ? Messages.NONE : maternalUncles.ToString().Trim());
        }

        internal static void GetPaternalAunts(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder paternalAunts = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                paternalAunts.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                if (familyMembers[personName].Father != null && familyMembers[personName].Father.Mother != null)
                {
                    foreach (Person p in familyMembers[personName].Father.Mother.Children)
                    {
                        if (p.PersonGender == Gender.Female)
                            paternalAunts.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(paternalAunts.ToString().Trim()) ? Messages.NONE : paternalAunts.ToString().Trim());
        }

        internal static void GetSisterInLaws(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder sisterInLaws = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                sisterInLaws.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                if (familyMembers[personName].Mother != null)
                {
                    foreach (Person p in familyMembers[personName].Mother.Children)
                    {
                        if (p.Name != personName && p.Spouse != null && p.Spouse.PersonGender == Gender.Female)
                            sisterInLaws.Append(p.Spouse.Name + " ");
                    }
                }
                if (familyMembers[personName].Spouse != null && familyMembers[personName].Spouse.Mother != null)
                {
                    foreach (Person p in familyMembers[personName].Spouse.Mother.Children)
                    {
                        if (p.Name != familyMembers[personName].Spouse.Name && p.PersonGender == Gender.Female)
                            sisterInLaws.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(sisterInLaws.ToString().Trim()) ? Messages.NONE : sisterInLaws.ToString().Trim());
        }

        internal static void GetBrotherInLaws(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder brotherInLaws = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                brotherInLaws.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                if (familyMembers[personName].Mother != null) {
                    foreach (Person p in familyMembers[personName].Mother.Children)
                    {
                        if (p.Name != personName && p.Spouse != null && p.Spouse.PersonGender == Gender.Male)
                            brotherInLaws.Append(p.Spouse.Name + " ");
                    }
                }
                if (familyMembers[personName].Spouse != null && familyMembers[personName].Spouse.Mother != null)
                {
                    foreach (Person p in familyMembers[personName].Spouse.Mother.Children)
                    {
                        if (p.Name != familyMembers[personName].Spouse.Name && p.PersonGender == Gender.Male)
                            brotherInLaws.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(brotherInLaws.ToString().Trim()) ? Messages.NONE : brotherInLaws.ToString().Trim());
        }

        internal static void GetMaternalAunts(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder maternalAunts = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                maternalAunts.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                if (familyMembers[personName].Mother != null && familyMembers[personName].Mother.Mother != null)
                {
                    foreach (Person p in familyMembers[personName].Mother.Mother.Children)
                    {
                        if (p.PersonGender == Gender.Female && p.Name != familyMembers[personName].Mother.Name)
                            maternalAunts.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(maternalAunts.ToString().Trim()) ? Messages.NONE : maternalAunts.ToString().Trim());
        }

        internal static void GetSiblings(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder siblings = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                siblings.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                foreach (Person p in familyMembers[personName].Mother.Children)
                {
                    if (p.Name != personName)
                        siblings.Append(p.Name + " ");
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(siblings.ToString().Trim()) ? Messages.NONE : siblings.ToString().Trim());
        }

        internal static void GetDaughters(string personName, IDictionary<string, Person> familyMembers)
        {
            StringBuilder daughters = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                daughters.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                foreach (Person p in familyMembers[personName].Children)
                {
                    if (p.PersonGender == Gender.Female)
                    {
                        daughters.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(daughters.ToString().Trim()) ? Messages.NONE : daughters.ToString().Trim());
        }

        internal static void GetSons(String personName, IDictionary<String, Person> familyMembers)
        {
            StringBuilder sons = new StringBuilder();
            if (personName == null || !familyMembers.ContainsKey(personName))
            {
                sons.Append(Messages.PERSON_NOT_FOUND);
            }
            else
            {
                foreach (Person p in familyMembers[personName].Children)
                {
                    if (p.PersonGender == Gender.Male)
                    {
                        sons.Append(p.Name + " ");
                    }
                }
            }
            Console.WriteLine(String.IsNullOrEmpty(sons.ToString().Trim()) ? Messages.NONE : sons.ToString().Trim());
        }
    }
}
