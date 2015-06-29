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

    // Two very general notes, which were well outside the scope of these excercises...

    /* Point 1.
(Our stock notes on this question....)
For exercise 12.1, 12.2, and 12.3 it's worth noting that the whilst this book demonstrates that
it’s possible to overload operators and shows you how, it is a little simplistic in the details.
If you were doing this for real you'd want to pay a lot more attention to what happens with null invoices
 – we really don’t want exceptions thrown from operator overloads.

There is a book called "Effective C#" that does a much more thorough job of explaining when and how to override equality methods and operators, that we highly recommend reading later on.

However, a quick summary of what equality methods you would normally want to override (see chapter 9 of “Effective C#” for more details) is:

For value types: Always override both .Equals() and operator==() - the default implementations are very inefficient.
For reference types: Override .Equals() if you want custom equality (and use the pattern in Effective C#). However, you usually leave operator==() alone as it is used by many .Net framework classes that you will probably want to work with your class.
If you override .Equals() it is really important to override GetHashCode() too.
GetHashCode() is used in collections like dictionaries the Dictionary may behave unexpectedly if the object equality and object HashCode logics do not match up.
In Generic Frameworks are liable to use the "knowledge" that if two objects have different HashCodes then they are not equal (though of course the opposite is not true!) and breaking that contract is liable to lead to unexepcted behaviour.
     */


    /*Point 2.
     * Again, this excercise is about operator overloads. But it's worth noting that there are .NET framework interfaces which relate to both equality and comparability: IEquatable and IComparable.
     * If one is going to go so far as to define the operators, it's generally worth implementing the interfaces too ... it's using the same logic
     * and it allows you to make use of framework methods such as IEnumerable.OrderBy() which in the simplest case requires it's target to implement IComparable.
     */
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
            // This is definitely the right way to go about defining the '!=' operator.
            // Between them the == and != should only have one definition.
            // Very occasionally you might want to actually define != and have == be the negation of that, but you should never have actual logic in both.
            return !(lhs == rhs);
        }

        public static bool operator < (Invoice lhs, Invoice rhs)
        {
            return lhs.amount < rhs.amount;
        }

        // See above comments about != and ==. Here I would have had > be defined as (!(<) && !=).
        // In fact, if you're defining the < & > then you might as well go the whole hog and define <= & >=.
        // Then you can define <, and get:
        // <=    ....    (<)  ||  (==)
        // >     ....    !(<=)
        // >=    ....    !(<)
        // and you've defined all 4 operators but only got one piece of actual comparitive logic
        // (and thus only one place to change if you decide that your logic needs updating)
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
