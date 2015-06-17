using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise21_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<Box>
            {
                new Box {Height = 3, Length = 4, Width = 2},
                new Box {Height = 3, Length = 4, Width = 1},
                new Box {Height = 3, Length = 7, Width = 5}, // this one
                new Box {Height = 3, Length = 3, Width = 5},
                new Box {Height = 1, Length = 4, Width = 5}, // and that one
                new Box {Height = 3, Length = 2, Width = 3}
            };

            var specialBoxes = boxes.Where(box => box.Length > 3 && box.Width > 3);

            foreach (var box in specialBoxes)
            {
                box.DisplayBox();
            }
        }
    }

    class Box
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void DisplayBox()
        {
            Console.WriteLine("{0}x{1}x{2}", Length, Width, Height);
        }
    }
}
