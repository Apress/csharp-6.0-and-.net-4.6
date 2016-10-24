﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace StringIndexer
{
    public class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople =
          new Dictionary<string, Person>();

        // This indexer returns a person based on a string index.
        public Person this[string name]
        {
            get { return (Person)listPeople[name]; }
            set { listPeople[name] = value; }
        }

        public void ClearPeople()
        { listPeople.Clear(); }

        public int Count
        { get { return listPeople.Count; } }

        IEnumerator IEnumerable.GetEnumerator()
        { return listPeople.GetEnumerator(); }
    }
}
