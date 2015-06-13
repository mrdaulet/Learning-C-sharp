using System;

namespace Exercise16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 10, 20, 30 };
            const string exitProgramCommand = "exit";

            while (true)
            {
                Console.WriteLine("Which array element to show? Type \"exit\" to close program.");
                string input = Console.ReadLine();

                if (input == exitProgramCommand)
                {
                    break;
                }

                try
                {
                    int index = int.Parse(input);
                    try
                    {
                        var element = array[index];
                        Console.WriteLine("Here is your element: {0}", element);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\"{0}\" is not a valid array index.", input);
                }
                catch
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
        }
    }
}
