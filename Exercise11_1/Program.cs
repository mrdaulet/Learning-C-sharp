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
            ElectronicPhone ep = new ElectronicPhone();
            ep.Ring();
        }

        static void Main(String[] args)
        {
            Program program = new Program();
            program.Run();
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
