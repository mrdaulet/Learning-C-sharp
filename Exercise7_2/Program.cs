using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Add(3, 4));
            Console.WriteLine(Math.Subtract(3, 4));
            Console.WriteLine(Math.Multiply(3, 4));
            Console.WriteLine(Math.Divide(3, 4));
        }
    }

    static class Math
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
