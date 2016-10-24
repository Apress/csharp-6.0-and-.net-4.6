using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle( int w, int h ) : this()
        {
            Width = w; Height = h;
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return string.Format("[Width = {0}; Height = {1}]",
              Width, Height);
        }

        public static implicit operator Rectangle( Square s )
        {
            Rectangle r = new Rectangle();
            r.Height = s.Length;

            // Assume the length of the new Rectangle with
            // (Length x 2)
            r.Width = s.Length * 2;
            return r;
        }

    }
}
