using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_1
{
    class Program
    {
        // Definitely a personal style thing, but I always remove Main's argument if it's unused - not that I've written more than about 10 Main statements in real code.
        // I shan't repeat that comment everywhere, obviously.
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

        // Excercise didn't specify the nature of the Division, so this is fine, but I might have named it "IntegerDivide()".
        // Obviously in reality one would never write such a trivial function, but if your method name is ever ambiguous it's worth clarifying.
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
