using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    public struct Square
    {
        public int Length { get; set; }

        public Square( int l ) : this()
        {
            Length = l;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        { return string.Format("[Length = {0}]", Length); }

        #region Conversion operations
        // Rectangles can be explicitly converted
        // into Squares.
        public static explicit operator Square( Rectangle r )
        {
            Square s = new Square();
            s.Length = r.Height;
            return s;
        }

        public static explicit operator Square( int sideLength )
        {
            Square newSq = new Square();
            newSq.Length = sideLength;
            return newSq;
        }

        public static explicit operator int( Square s )
        { return s.Length; }
        #endregion
    }

}
