using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var math = new Math();
            Console.WriteLine(math.Add(3, 4));
            Console.WriteLine(math.Subtract(3, 4));
            Console.WriteLine(math.Multiply(3, 4));
            Console.WriteLine(math.Divide(3, 4));
        }
    }

    class Math 
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
