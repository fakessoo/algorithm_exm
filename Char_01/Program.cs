using System;

namespace Char_01
{
    class Program
    {
        static void Main(string[] args)
        {
            char chA = 'A';
            char ch1 = '1';
            string str = "test string";

            Console.WriteLine(chA.CompareTo('B'));
            Console.WriteLine(chA.Equals('A'));
            Console.WriteLine(Char.GetNumericValue(ch1));
            Console.WriteLine(Char.IsControl('\t'));
            Console.WriteLine(Char.IsDigit(ch1));
            Console.WriteLine(Char.IsLetter(','));
            Console.WriteLine(Char.IsLower('u'));
            Console.WriteLine(Char.IsNumber(ch1));
            Console.WriteLine(Char.IsPunctuation('.'));
            Console.WriteLine(Char.IsSeparator(str, 4));
            Console.WriteLine(Char.IsSymbol('+'));
            Console.WriteLine(Char.IsWhiteSpace(str, 4));
            Console.WriteLine(Char.Parse("S"));
            Console.WriteLine(Char.ToLower('M'));
            Console.WriteLine('x'.ToString());

        }
    }
}
