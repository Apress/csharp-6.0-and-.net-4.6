﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefTypeValTypeParams
{
    #region Simple Person class
    class Person
    {
        public string personName;
        public int personAge;

        // Constructors.
        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }
        public Person() { }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }
    } 
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            // Passing ref-types by ref.
            Console.WriteLine("***** Passing Person object by reference *****\n");
            Person mel = new Person("Mel", 23);
            Console.WriteLine("Before by ref call, Person is:");
            mel.Display();

            SendAPersonByReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display();
            Console.ReadLine();

        }

        #region Helper functions
        static void SendAPersonByValue(Person p)
        {
            // Change the age of "p"?
            p.personAge = 99;

            // Will the caller see this reassignment?
            p = new Person("Nikki", 99);
        }

        static void SendAPersonByReference(ref Person p)
        {
            // Change some data of "p".
            p.personAge = 555;

            // "p" is now pointing to a new object on the heap!
            p = new Person("Nikki", 999);
        }
        #endregion
    }
}
