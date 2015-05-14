using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12_3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Invoice
    {
        string vendor;
        double amount;

        public override string ToString()
        {
            return vendor + " " + amount;
        }
    }
}
