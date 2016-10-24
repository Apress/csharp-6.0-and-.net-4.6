﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Strings *****\n");
            BasicStringFunctionality();
            StringConcatenation();
            EscapeChars();
            StringsAreImmutable();
            FunWithStringBuilder();
            StringInterpolation();
            Console.ReadLine();
        }

        #region String basics
        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters.", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains the letter y?: {0}",
              firstName.Contains("y"));
            Console.WriteLine("New first name: {0}", firstName.Replace("dy", ""));
            Console.WriteLine();
        }
        #endregion

        #region Concatenation
        static void StringConcatenation()
        {
            Console.WriteLine("=> String concatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = s1 + s2;
            Console.WriteLine(s3);
            Console.WriteLine();
        }
        #endregion

        #region Escape Chars
        static void EscapeChars()
        {
            Console.WriteLine("=> Escape characters:\a");
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a ";
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Everyone loves \"Hello World\"\a ");
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");

            // Adds a total of 4 blank lines (then beep again!).
            Console.WriteLine("All finished.\n\n\n\a ");
            Console.WriteLine();

            // The following string is printed verbatim
            // thus, all escape characters are displayed.
            Console.WriteLine(@"C:\MyApp\bin\Debug");

            // White space is preserved with verbatim strings.
            string myLongString = @"This is a very
                 very
                      very
                           long string";
            Console.WriteLine(myLongString);
            Console.WriteLine();
            Console.WriteLine(@"Cerebus said ""Darrr! Pret-ty sun-sets""");
        }
        #endregion

        #region Immutable test
        static void StringsAreImmutable()
        {
            //// Set initial string value.
            //string s1 = "This is my string.";
            //Console.WriteLine("s1 = {0}", s1);

            //// Uppercase s1?
            //string upperString = s1.ToUpper();
            //Console.WriteLine("upperString = {0}", upperString);

            //// Nope! s1 is in the same format!
            //Console.WriteLine("s1 = {0}", s1);

            string s2 = "My other string";
            s2 = "New string value";
            Console.WriteLine(s2);
        }
        #endregion

        #region StringBuilder
        static void FunWithStringBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");

            // Make a StringBuilder with an initial size of 256.
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 256);

            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Beyond Good and Evil");
            sb.AppendLine("Deus Ex 2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());

            sb.Replace("2", "Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }
        #endregion

        #region String interpolation
        static void StringInterpolation()
        {
            // Some local variables we will plug into our larger string
            int age = 4;
            string name = "Soren";

            // Using curly bracket syntax.
            string greeting = string.Format("\tHello {0} you are {1} years old.", name.ToUpper(), age);
            Console.WriteLine(greeting);

            // Using string interpolation
            string greeting2 = $"\tHello {name.ToUpper()} you are {age} years old.";
            Console.WriteLine(greeting2);
        }
        #endregion
    }
}
