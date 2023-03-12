using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string> { "This is", "an example", "text", "that can", "be", "to analize", "it legth" };

            Func<string, int> stringLength = s => s.Length;

            List<int> stringLengths = strings.Select(stringLength).ToList();

            Console.WriteLine("Strings:");
            foreach (string s in strings)
            {
                Console.WriteLine($"- {s}");
            }
            Console.WriteLine("String Lengths:");
            foreach (int length in stringLengths)
            {
                Console.WriteLine($"- {length}");
            }
        }
    }
}
