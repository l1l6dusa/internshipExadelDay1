using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempInt = 0;
            Random random = new Random();
            List<Issue> bugList = new List<Issue>();
            List<Issue> testCaseList = new List<Issue>();
            while (true)
            {
                Console.Clear();
                if (bugList.Count>0)
                {
                    Console.WriteLine($"Current bug quantity: {bugList.Count}");
                }

                if (testCaseList.Count > 0)
                {
                    Console.WriteLine($"Current test cases quantity: {testCaseList.Count}");
                }
                {
                    
                }
                Console.WriteLine("Select action: \n1. Generate test case\n2. Generate bug ticket;\n3. Show generated test cases\n4. Shown generated bug tickets");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    switch (value)
                    {
                        case 1:
                            Console.Clear();
                            tempInt = random.Next(0, 6);
                            for (int i = 0; i < tempInt; i++)
                            {
                                testCaseList.Add(IssueBuilder.CreateTestCase());
                            }
                            Console.WriteLine($"{tempInt} test cases created, press any button to continue");
                            Console.ReadKey();
                            continue;
                        case 2:
                            Console.Clear();
                            tempInt = random.Next(0, 6);
                            for (int i = 0; i < tempInt; i++)
                            {
                                bugList.Add(IssueBuilder.CreateBug());
                            }
                            Console.WriteLine($"{tempInt} bugs created, press any button to continue");
                            Console.ReadKey();
                            continue;
                        case 3:
                            Console.Clear();
                            if (testCaseList.Count > 0)
                            {
                                foreach (var testCase in testCaseList)
                                {
                                    testCase.Display();
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Press any button to continue");
                            }
                            else
                            {
                                Console.WriteLine("No test cases found, press any button to continue");
                            }
                            Console.ReadKey();
                            continue;
                        case 4:
                            Console.Clear();
                            if (bugList.Count > 0)
                            {
                                foreach (var bug in bugList)
                                {
                                    bug.Display();
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Press any button to continue");
                            }
                            else
                            {
                                Console.WriteLine("No bugs found, press any button to continue");
                            }
                            
                            Console.ReadKey();
                            continue;
                        default:
                            Console.WriteLine("Incorrect input, press any button to continue");
                            Console.ReadKey();
                            continue;
                    }
                }
                Console.WriteLine("Only integers are available");
            }
        }
    }
}