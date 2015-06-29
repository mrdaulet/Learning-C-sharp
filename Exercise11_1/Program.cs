using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11_1
{
    class Program
    {
        private void Run()
        {
            // Variable names that are just initials are almost always a bad idea.
            // In this particular case it's not so important, but in a larger method it's easy to lose track of what the variable was (especially if you didn't write the code.)
            // Also you can use var here instead of repeating ElectronicPhone
            var phone = new ElectronicPhone();
            phone.Ring();
        }

        static void Main(String[] args)
        {
            //Note that since you only use the variable once, you don't actually need to store the program object in a variable.
            // - you could just invoke the method on it directly (Same is true above.)
            (new Program()).Run();
        }
    }

    class Telephone 
    {
        protected String phoneType;

        public void Ring()
        {
            Console.WriteLine("Ringing the {0}.", phoneType);
        }
    }

    class ElectronicPhone : Telephone
    {
        public ElectronicPhone()
        {
            phoneType = "Digital";
        }
    }
}
