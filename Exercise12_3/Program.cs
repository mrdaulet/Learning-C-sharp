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
            var invoiceA = new Invoice("A", 13);
            var invoiceB = new Invoice("B", 18);
            var invoiceA2 = new Invoice("A", 10);

            Console.WriteLine("{0}, {1}, {2}", invoiceA, invoiceA2, invoiceB);
            Console.WriteLine("{0} + {1} = {2}", invoiceA, invoiceA2, invoiceA + invoiceA2);
            Console.WriteLine("{0} + {1} = {2}", invoiceA, invoiceB, invoiceA + invoiceB);

            var invoiceACopy = new Invoice("A", 13);
            Console.WriteLine("{0} == {1} is {2}", invoiceA, invoiceACopy, invoiceA == invoiceACopy);
            Console.WriteLine("{0} == {1} is {2}", invoiceA, invoiceA2, invoiceA == invoiceA2);
            Console.WriteLine("{0} == {1} is {2}", invoiceA, invoiceB, invoiceA == invoiceB);

            invoiceB.amount = 13;
            Console.WriteLine("{0} < {1} is {2}", invoiceA, invoiceA2, invoiceA < invoiceA2);
            Console.WriteLine("{0} < {1} is {2}", invoiceA, invoiceB, invoiceA < invoiceB);
            Console.WriteLine("{0} > {1} is {2}", invoiceA, invoiceA2, invoiceA > invoiceA2);
            Console.WriteLine("{0} > {1} is {2}", invoiceA, invoiceB, invoiceA > invoiceB);

        }
    }

    class Invoice
    {
        public string vendor;
        public double amount;

        public Invoice(string vendor, double amount)
        {
            this.vendor = vendor;
            this.amount = amount;
        }

        public override string ToString()
        {
            return vendor + " " + amount;
        }

        public static double operator + (Invoice lhs, Invoice rhs)
        {
            if (lhs.vendor == rhs.vendor)
            {
                return lhs.amount + rhs.amount;
            }

            return 0;
        }

        public static bool operator == (Invoice lhs, Invoice rhs)
        {
            return lhs.vendor == rhs.vendor && lhs.amount == rhs.amount;
        }

        public static bool operator != (Invoice lhs, Invoice rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator < (Invoice lhs, Invoice rhs)
        {
            return lhs.amount < rhs.amount;
        }

        public static bool operator > (Invoice lhs, Invoice rhs)
        {
            return lhs.amount > rhs.amount;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Invoice))
            {
                return false;
            }
            return !(this == (Invoice)obj);
        }
    }
}
