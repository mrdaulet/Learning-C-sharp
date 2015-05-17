using System;

namespace Exercise13
{
    internal interface IConvertible
    {
        string ConvertToCSharp(string code);
        string ConvertToVB(string code);
    }

    interface ICodeChecker : IConvertible
    {
        bool CodeCheckSyntax(string code, string language);
    }

    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public override string ConvertToCSharp(string code)
        {
            Console.WriteLine("\"{0}\" is now C# code.", code);
            return null;
        }

        public override string ConvertToVB(string code)
        {
            Console.WriteLine("\"{0}\" is now Visual Basic code.", code);
            return null;
        }

        public bool CodeCheckSyntax(string code, string language)
        {
            Console.WriteLine("Checking code.");
            return true;
        }
    }

    class ProgramConverter : IConvertible
    {
        public virtual string ConvertToCSharp(string code)
        {
            Console.WriteLine("ProgramConverts {0} to C#.", code);
            return null;
        }

        public virtual string ConvertToVB(string code)
        {
            Console.WriteLine("ProgramConverts {0} to VB.", code);
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ph = new ProgramHelper();

            ph.ConvertToCSharp("VB code");
            ph.ConvertToVB("C# code");
            ph.CodeCheckSyntax("Some code", "Pascal");

            var programConverters = new ProgramConverter[5];
            for (int i = 0; i < programConverters.Length; i++)
            {
                var newObject = i%2 == 0 ? new ProgramConverter() : new ProgramHelper();
                programConverters[i] = newObject;
            }

            foreach (var converter in programConverters)
            {
                Console.WriteLine();
                if (converter is ProgramHelper)
                {
                    var helper = converter as ProgramHelper;
                    helper.ConvertToCSharp("A");
                    helper.ConvertToVB("B");
                    helper.CodeCheckSyntax("Hello", "English");
                }
                var codeChecker = converter as ICodeChecker;

                if (codeChecker != null)
                {
                    codeChecker.CodeCheckSyntax("Blablabla", "Dracula");
                }

                var iConvertible = converter as IConvertible;
                if (iConvertible != null)
                {
                    iConvertible.ConvertToVB("iConvertible VB");
                    iConvertible.ConvertToCSharp("iConvertible CSharp");
                }
            }
        }
    }
}
