using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary
{
    public static class StringExtentions
    {
        public static string PadBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);

        }
    }

    public class Design
    {
        public static string PadBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);

        }

        public static void FrameLeft(string mystring)
        {
            Console.WriteLine("| "+mystring.PadLeft(10, ' '));
        }

        public static void Padding(string mystring)
        {
            Console.WriteLine("  |  " + mystring.PadRight(22, ' ') + "|");
        }

        public void FrameRight(string mystring)
        {
            Console.WriteLine(mystring.PadRight(28, '|'));
        }
    }
}
