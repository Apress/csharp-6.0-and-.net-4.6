using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            if (on)
                Console.WriteLine("Jamming...");
            else
                Console.WriteLine("Quiet time...");
        }
    }
}
