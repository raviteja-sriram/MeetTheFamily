using System;
using System.Collections.Generic;
using System.Text;

namespace geektrust.Models
{
    public class Relationships
    {
        private Dictionary<String, Action<String, IDictionary<String, Person>>> _relationships = new Dictionary<string, Action<string, IDictionary<string, Person>>>();
        public Relationships()
        {
            _relationships.Add(RelationshipsHelper.Son, RelationshipsHelper.GetSons);
            _relationships.Add(RelationshipsHelper.Daughter, RelationshipsHelper.GetDaughters);
            _relationships.Add(RelationshipsHelper.Siblings, RelationshipsHelper.GetSiblings);
            _relationships.Add(RelationshipsHelper.Paternal_Uncle, RelationshipsHelper.GetPaternalUncles);
            _relationships.Add(RelationshipsHelper.Maternal_Uncle, RelationshipsHelper.GetMaternalUncles);
            _relationships.Add(RelationshipsHelper.Paternal_Aunt, RelationshipsHelper.GetPaternalAunts);
            _relationships.Add(RelationshipsHelper.Maternal_Aunt, RelationshipsHelper.GetMaternalAunts);
            _relationships.Add(RelationshipsHelper.Sister_In_Law, RelationshipsHelper.GetSisterInLaws);
            _relationships.Add(RelationshipsHelper.Brother_In_Law, RelationshipsHelper.GetBrotherInLaws);
        }

        public void GetRelation(Dictionary<String, Person> familMembers, String personName, String relation)
        {
            if (_relationships.ContainsKey(relation))
            {
                _relationships[relation].Invoke(personName, familMembers);
            }
            else
            {
                Console.WriteLine(Messages.INVALID_COMMAND);
            }
        }
    }
}
