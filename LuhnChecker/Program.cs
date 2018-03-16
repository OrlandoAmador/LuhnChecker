using System;
using System.Linq;

namespace LuhnChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter CC Number -- type e to exit");

            string cc;
            while ((cc = Console.ReadLine()?.ToUpper()) != "E")
            {
                if (cc == null && cc.Length < 14)
                {
                    Console.WriteLine("Invalid CC Info");
                }
                var results = Luhn(cc);
                Console.WriteLine(results);
            }
        }

        public static bool Luhn(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                       .Select(c => c - 48)
                       .Select((thisNum, i) => i % 2 == 0
                           ? thisNum
                           : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                       ).Sum() % 10 == 0;
        }
    }
}
