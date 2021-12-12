using System;

namespace HomeWork2
{
    public static class Helper
    {
        public static int Choose(params string[] args)
        {
            while (true)
            {
                Console.Clear();
                for (var i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {args[i]}");
                }

                Console.Write($"Select the value between 1-{args.Length}: ");
                if (int.TryParse(Console.ReadLine(), out var value) && value > 0 && value <= args.Length)
                {
                    return value;
                }
                Console.WriteLine("Incorrect input, press any button to continue");
                Console.Read();
            }
        }
        public static int Choose(string title, params string[] args)
        {
            while (true)
            {
                Console.WriteLine(title);
                for (var i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {args[i]}");
                }

                Console.Write($"Select the value between 1-{args.Length}: ");
                if (int.TryParse(Console.ReadLine(), out var value) && value > 0 && value <= args.Length)
                {
                    return value;
                }
                Console.WriteLine("Incorrect input, press any button to continue");
                Console.Read();
            }
        }
        
        public static string Capitalize(this string target)
        {
            var charArray = target.ToCharArray();
            charArray[0] = Char.ToUpper(charArray[0]);
            return String.Concat(charArray);
        }
    }
}