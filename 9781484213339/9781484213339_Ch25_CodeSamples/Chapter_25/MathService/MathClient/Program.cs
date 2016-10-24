using System;
using MathClient.ServiceReference1;
using System.Threading;

namespace MathClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Async Math Client *****\n");

            using (BasicMathClient proxy = new BasicMathClient())
            {
                proxy.Open();

                // Add numbers in an async manner, using lambda expression
                IAsyncResult result = proxy.BeginAdd(2, 3,
                  ar =>
                  {
                      Console.WriteLine("2 + 3 = {0}", proxy.EndAdd(ar));
                  }, null);

                while (!result.IsCompleted)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Client working...");
                }
            }
            Console.ReadLine();
        }
    }
}
