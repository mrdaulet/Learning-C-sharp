using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(6, 8);
            int length = 4;

            Square sq = new Square(p, length);

            p.Display();
            sq.Display();
        }
    }

    class Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Display()
        {
            Console.WriteLine("({0}, {1})", x, y);
        }

    }

    class Square
    {
        private Point[] corners = new Point[4];
        private int length;

        public Square(Point topLeft, int length)
        {
            this.length = length;
            corners[0] = new Point(topLeft.x, topLeft.y); // Top left (assuming (0,0) in this coordinate system is top left)
            corners[1] = new Point(topLeft.x + length, topLeft.y); // Top right
            corners[2] = new Point(topLeft.x, topLeft.y + length); // Bottom left
            corners[3] = new Point(topLeft.x + length, topLeft.y + length); // Bottom right
        }

        public void Display()
        {
            Console.WriteLine("Corners of the square:");
            foreach (var point in corners)
            {
                point.Display();                
            }
        }
    }
}
