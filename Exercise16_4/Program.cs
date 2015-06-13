using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise16_4
{
    class CatManager
    {
        static void Main(string[] args)
        {
            try
            {
                var cats = new List<Cat>();
                cats.Add(new Cat(1));
                cats.Add(new Cat(2));
                cats.Add(new Cat(0));
                cats.Add(new Cat(-92));
                cats.Add(new Cat(2));
            }
            catch (CustomCatError e)
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
            if (age <= 0)
                throw new CustomCatError(string.Format("Given age: {0}. Cat's age cannot be less than or equal to 0.", age));
            Age = age;
        }
    }

    class CustomCatError : ApplicationException
    {
        public CustomCatError(string message) : base(message) 
        { }
    }
}
