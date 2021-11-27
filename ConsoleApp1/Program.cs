using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main()
        {
            /*#region ex1
            var arrayOne = PopulateArray(10);
            var arrayTwo = PopulateArray(10);
            var arrayThree = PopulateArray(10);

            Console.WriteLine("Array.Sort()");
            ReadIntArray(arrayOne);
            ReadIntArray(SortArray(arrayOne));
            Console.WriteLine("Linq OrderBy");
            ReadIntArray(arrayTwo);
            ReadIntArray(SortLinq(arrayTwo));
            Console.WriteLine("SortIterativeBitwise");
            ReadIntArray(arrayThree);
            ReadIntArray(SortIterativeBitwise(arrayThree));
            #endregion*/

            var builder = new BugBuilder();
            List<Bug> _jira = new List<Bug>();
            while (true)
            {
                Console.WriteLine("Select:\n 1 - Create a bug\n 2 - Show a bug\n 3 - Show bug qty");
                if (int.TryParse(Console.ReadLine(), out var result))
                {
                    switch (result)
                    {
                         case 1:
                             _jira.Add(builder.CreateBug());
                             break;
                         case 2:
                             while (true)
                             {
                                 if (_jira.Count == 0)
                                 {
                                     Console.WriteLine("Jira is empty.");
                                     break;
                                 }
                                 Console.WriteLine("Select a bug ID:");
                                 if (int.TryParse(Console.ReadLine(), out var value))
                                 {
                                     if (value >=0 && value<_jira.Count)
                                     {
                                         _jira[value].DisplayInfo();
                                         break;
                                     }
                                 }
                                 Console.WriteLine("Incorrect bug ID");
                             }
                             break;
                         case 3:
                             Console.WriteLine($"Current bug count: {_jira.Count}");
                             break;
                         default:
                             Console.WriteLine("Incorrect input, try again");
                             break;
                    }
                }
            }
            
        }
        
        private static int[] PopulateArray(int length)
        {
            var tempArray = new int[length];
            var rand = new Random();
            for (int i = 0; i < length; i++)
            {
                tempArray[i] = rand.Next(0, 1000);
            }

            return tempArray;
        }
        
        private static int[] SortArray(int[] array)
        {
            var tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            Array.Sort(tempArray, (x, y) => x.CompareTo(y));
            return tempArray;
        }
        

        private static int[] SortLinq(int[] array)
        {
            var tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            return tempArray.OrderBy(x => x).ToArray();
        }
        
        
        
        
        private static int[] SortIterativeBitwise(int[] array)
        {
            var tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                for (int j = i + 1; j < tempArray.Length; j++)
                    if (tempArray[i] > tempArray[j])
                    {
                        tempArray[i] = tempArray[i] ^ tempArray[j];
                        tempArray[j] = tempArray[j] ^ tempArray[i];
                        tempArray[i] = tempArray[i] ^ tempArray[j];
                    }
            }
            return tempArray;
        }

        private static void ReadIntArray(int[] array)
        {
            foreach (var num in array)
            {
                Console.Write(num + "\t");
            }
            Console.WriteLine();
        }
    }
}