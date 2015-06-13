using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise16_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cats = new List<Cat>();
                cats.Add(new Cat(0));
                cats.Add(new Cat(2));
                cats.Add(new Cat(100));
                cats.Add(new Cat(-92));
                cats.Add(new Cat(2));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("Some other exception.");
            }
            finally
            {
                Console.WriteLine("Pretending to deallocate cats back to CatVille");
            }
        }
    }

    class Cat
    {
        public int Age { get; set; }

        public Cat(int age)
        {
            if (age < 0)
                throw new ArgumentOutOfRangeException(age.ToString(), "Cats do not live in the backwards direction.");
            Age = age;
        }
    }
}
