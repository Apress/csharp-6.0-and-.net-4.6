﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringWithOperators();
            Console.WriteLine();

            QueryStringsWithEnumerableAndLambdas();
            Console.WriteLine();

            QueryStringsWithAnonymousMethods();
            Console.WriteLine();

            VeryComplexQueryExpression.QueryStringsWithRawDelegates();
            Console.WriteLine();

            Console.ReadLine();
        }

        #region Use Linq operators
        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            var subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
        #endregion

        #region With enumerable and lambdas
        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Build a query expression using extension methods
            // granted to the Array via the Enumerable type.
            var subset = currentVideoGames.Where(game => game.Contains(" "))
              .OrderBy(game => game).Select(game => game);

            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();

        }
        static void QueryStringsWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Break it down!
            var gamesWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
            var orderedGames = gamesWithSpaces.OrderBy(game => game);
            var subset = orderedGames.Select(game => game);

            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
        #endregion

        #region With anonymous methods
        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Build the necessary Func<> delegates using anonymous methods.
            Func<string, bool> searchFilter =
                delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };

            // Pass the delegates into the methods of Enumerable.
            var subset = currentVideoGames.Where(searchFilter)
                .OrderBy(itemToProcess).Select(itemToProcess);

            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
        #endregion
    }
}
