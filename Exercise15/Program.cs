using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercise15
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise15_1();
            Exercise15_2();
            Exercise15_3();
            Exercise15_4();
        }

        private static void Exercise15_4()
        {
            const string muricaSpeaks2 = "We hold these truths to be self-evident, that all men are created equal, that they are endowed by their Creator with certain unalienable Rights, that among these are Life, Liberty and the pursuit of Happiness.";
            Console.WriteLine(muricaSpeaks2);
            var regex = new Regex(@" |,|\.|, |\. ");
            var words = regex.Split(muricaSpeaks2).Where(s => s.Length != 0).ToArray();
            var sb = new StringBuilder();
            for (int index = 0; index < words.Length; index++)
            {
                sb.AppendFormat("{0}: {1}\n", index, words[index]);
            }
            var newString = sb.ToString();
            Console.WriteLine(newString);
        }

        private static void Exercise15_3()
        {
            const string muricaSpeaks = "We choose to go to the moon. We choose to go to the moon in this decade and do the other things, not because they are easy, but because they are hard, because that goal will serve to organize and measure the best of our energies and skills, because that challenge is one that we are willing to accept, one we are unwilling to postpone, and one which we intend to win, and the others, too.";
            Console.WriteLine(muricaSpeaks);
            var regex = new Regex(@" |,|\.|, |\. ");
            var words = regex.Split(muricaSpeaks);
            int theCount = 0;
            words.Where(s => s.Equals("the", StringComparison.CurrentCultureIgnoreCase)).ToList().ForEach( _ => theCount++ );
            Console.WriteLine("Number of 'the's: {0}", theCount);
        }

        private static void Exercise15_2()
        {
            const string shakingSpear = "To be, or not to be, that is the question: Whether 'tis Nobler in the mind to suffer the Slings and Arrows of outrageous Fortune, or to take Arms against a Sea of troubles, and by opposing end them?";
            Console.WriteLine(shakingSpear);
            var regex = new Regex(@", | |\. |: |,|:|\.|\?");
            var words = regex.Split(shakingSpear);
            words = words.Reverse().Where(x => x.Length != 0).ToArray();
            foreach (var word in words)
            {
                Console.Write("\"{0}\" ", word);
            }
            Console.WriteLine();
        }

        private static void Exercise15_1()
        {
            string s1 = "Hello", s2 = "World", s3 = @"Come visit us at http://www.LibertyAssociates.com";
            string s4 = s1 + s2;
            string s5 = "world";
            string s6 = s3;

            var strings = new [] {s1, s2, s3, s4, s5, s6};

            foreach (var s in strings)
            {
                Console.WriteLine("String {0}: length = {1}, s[3] = {2}, appears 'H' = {3}", s, s.Length, s[3], s.Contains('H'));
            }

            Console.WriteLine("Compare case-sensitive:");
            strings.Where(s => s == s2).ToList().ForEach( s => Console.WriteLine("{0} == {1}", s, s2) );
            Console.WriteLine("Compare, ignore case:");
            strings.Where(s => s.Equals(s2, StringComparison.CurrentCultureIgnoreCase)).ToList().ForEach(s => Console.WriteLine("{0} == {1}", s, s2));
        }
    }
}
