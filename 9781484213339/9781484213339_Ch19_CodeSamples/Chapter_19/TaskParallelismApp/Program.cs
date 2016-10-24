using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Net;

namespace TaskParallelismApp
{
    class Program
    {
        static void Main()
        {
            // Retrieve Darwin's "Origin of the Species" from Gutenberg.org.
            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/2009/2009.txt");
            System.IO.File.WriteAllLines("DarwinBook.txt", words);

            #region ParallelTasks
            // Perform three tasks in parallel on the source array
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task...");
                GetLongestWord(words);
            },  // close first Action

             () =>
             {
                 Console.WriteLine("Begin second task...");
                 GetMostCommonWords(words);
             }, //close second Action

             () =>
             {
                 Console.WriteLine("Begin third task...");
                 GetCountForWord(words, "species");
             } //close third Action
         ); //close parallel.invoke

            Console.WriteLine("Returned from Parallel.Invoke");
            #endregion

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        #region HelperMethods
        private static void GetCountForWord(string[] words, string term)
        {
            var findWord = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;

            Console.WriteLine(@"Task 3 -- The word ""{0}"" occurs {1} times.",
                term, findWord.Count());
        }

        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            var commonWords = frequencyOrder.Take(10);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 -- The most common words are:");
            foreach (var v in commonWords)
            {
                sb.AppendLine("  " + v);
            }
            Console.WriteLine(sb.ToString());
        }

        private static string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words
                               orderby w.Length descending
                               select w).First();

            Console.WriteLine("Task 1 -- The longest word is {0}", longestWord);
            return longestWord;
        }


        // An http request performed synchronously for simplicity.
        static string[] CreateWordArray(string uri)
        {
            Console.WriteLine("Retrieving from {0}", uri);

            // Download a web page the easy way.
            string s = new WebClient().DownloadString(uri);
            System.IO.File.WriteAllText("Book.txt", s);

             // Separate string into an array of words, removing some common punctuation.
            return s.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }
        #endregion
    }
}
