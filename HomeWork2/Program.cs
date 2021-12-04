using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
                Console.WriteLine("Select action: \n1. Generate test case\n" +
                                  "2. Generate bug ticket\n" +
                                  "3. Show generated test cases\n" +
                                  "4. Shown generated bug tickets\n" +
                                  "5. Remove the test case\n" +
                                  "6. Remove bug\n" +
                                  "7. Create Test case\n" +
                                  "8. Create bug");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    switch (value)
                    {
                        case 1:
                            Console.Clear();
                            tempInt = random.Next(0, 6);
                            for (int i = 0; i < tempInt; i++)
                            {
                                testCaseList.Add(IssueBuilder.GenerateTestCases());
                            }
                            Console.WriteLine($"{tempInt} test cases created, press any button to continue");
                            Console.ReadKey();
                            continue;
                        case 2:
                            Console.Clear();
                            tempInt = random.Next(0, 6);
                            for (int i = 0; i < tempInt; i++)
                            {
                                bugList.Add(IssueBuilder.GenerateBugs());
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
                        case 5:
                            if (testCaseList.Count > 0)
                            {
                                foreach (var testcase in testCaseList)
                                {
                                    Console.WriteLine($"ID: {testcase.Id} Summary: {testcase.Summary} Status: {testcase.Status}");
                                }
                                Console.WriteLine("Select the ID of the test case which shall be removed: ");
                                if (int.TryParse(Console.ReadLine(), out value))
                                {
                                    if (testCaseList.Find(x=>x.Id == value) != null)
                                    {
                                        testCaseList.RemoveAll(x => x.Id == value);
                                        Console.WriteLine($"TestCase with ID {value} is removed, press any button to continue");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect input, press any button to continue");
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect input, press any button to continue");
                                }
                            }
                            else
                            {
                                Console.WriteLine("List is empty, press any button to continue");
                            }
                            
                            Console.ReadKey();
                            continue;
                        case 6:
                            if (bugList.Count > 0)
                            {
                                foreach (var bug in bugList)
                                {
                                    Console.WriteLine($"ID: {bug.Id} Summary: {bug.Summary} Status: {bug.Status}");
                                }
                                Console.WriteLine("Select the ID of the bug which shall be removed: ");
                                if (int.TryParse(Console.ReadLine(), out value))
                                {
                                    if (bugList.Find(x=>x.Id == value) != null)
                                    {
                                        bugList.RemoveAll(x => x.Id == value);
                                        Console.WriteLine($"Bug with ID {value} is removed, press any button to continue");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect input, press any button to continue");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect input, press any button to continue");
                                }
                            }
                            else
                            {
                                Console.WriteLine("List is empty, press any button to continue");
                            }
                            
                            Console.ReadKey();
                            continue;
                        case 7:
                            testCaseList.Add(IssueBuilder.CreateTestCase());
                            break;
                        case 8:
                            testCaseList.Add(IssueBuilder.CreateBug());
                            break;
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