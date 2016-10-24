using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Location of the proxy. 
using MagicEightBallServiceClient.ServiceReference;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Ask the Magic 8 Ball *****\n");

        using (EightBallClient ball = new EightBallClient("BasicHttpBinding_IEightBall"))
        {
            Console.Write("Your question: ");
            string question = Console.ReadLine();
            string answer =
              ball.ObtainAnswerToQuestion(question);
            Console.WriteLine("8-Ball says: {0}", answer);
        }
            Console.ReadLine();
        }
    }
}
