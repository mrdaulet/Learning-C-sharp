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
        //Naming convention is for public fields to be named like Properties, so X & Y.
        public int X, Y;

        public Point(int x, int y)
        {
            //Conveniently the rename means that the "this" is isn't necessary.
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine("({0}, {1})", X, Y);
        }

    }

    class Square
    {
        // Ooh ... interesting case. A collection whose size is fundamentally fixed is indeed a good argument for an array over a List.
        // OTOH, what do the indexes mean? If you want a particular corner how do you get it out of the array?
        // It might be worth declaring some constants like so:
        private int topLeftCornerIndex = 0;
        private int topRightCornerIndex = 1;
        private int bottomLeftCornerIndex = 2;
        private int bottomRightCornerIndex = 3;
        //Of course, by the time you're doing that, it might be easier to just define each point separately.

        private Point[] corners = new Point[4];
        private int length; // Unused variable - you (correctly, IMO) use this value to set the points in the constructor, and nowhere else.

        /// <summary>
        ///   Initialises a square of given side length, located by fixing the top-left corner.
        /// </summary>
        /// <param name="topLeft">Co-ordinates of the top-left point, (assuming (0,0) in this coordinate system lies in the top left of the graph.)</param>
        /// <param name="length">Side Length</param>
        public Square(Point topLeft, int length)
        {
            this.length = length;
            // It might have been worth factoring out the X & Y co-ordinates like this.
            // You'll see that doing so renders your comments unnecessary.
            // If you can make your code document things instead of comments, it's almost always better to do so.
            // Not least because the code is WAY more likely to stay up-to-date.
            var topY = topLeft.Y;
            var bottomY = topY + length;
            var leftX = topLeft.X;
            var rightX = leftX + length;
            corners[topLeftCornerIndex] = new Point(leftX, topY); // (assuming (0,0) in this coordinate system is top left) This comment is critical to the user of the class, so it's worth putting it in an XML comment so that Intellisense exposes it to you. See above.
            corners[topRightCornerIndex] = new Point(rightX, topY); 
            corners[bottomLeftCornerIndex] = new Point(leftX, bottomY);
            corners[bottomRightCornerIndex] = new Point(rightX, bottomY); 
        }

        //c.f. all the comments from 7.3
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
