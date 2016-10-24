using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SimpleIndexer
{
    public class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();

        // Cast for caller.
        public Person GetPerson(int pos)
        { return (Person)arPeople[pos]; }

        // Only insert Person types.
        public void AddPerson(Person p)
        { arPeople.Add(p); }

        public void ClearPeople()
        { arPeople.Clear(); }

        public int Count
        { get { return arPeople.Count; } }

        // Foreach enumeration support.
        IEnumerator IEnumerable.GetEnumerator()
        { return arPeople.GetEnumerator(); }

        // Custom indexer for this class.
        public Person this[int index]
        {
            get { return (Person)arPeople[index]; }
            set { arPeople.Insert(index, value); }
        }
    }
}
