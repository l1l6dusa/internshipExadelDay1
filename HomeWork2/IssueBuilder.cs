using System;
using System.Collections.Generic;

namespace HomeWork2
{
    public static class IssueBuilder
    {
        private static Random _random = new Random();

        public static Bug GenerateBugs()
        {
            var tempBug = new Bug((Priority)_random.Next(0, 5), "test", "test", (Status)_random.Next(0, 5),
                _random.Next(0, 11), _random.Next(0, 11), "test", "test");
            return tempBug;
        }

        public static TestCase GenerateTestCases()
        {
            List<Step> tempSteps = new List<Step>();
            for (var i = 0; i < _random.Next(1, 6); i++)
            {
                tempSteps.Add(new Step(i, $"{i} action", $"{i} result"));
            }

            var tempTestCase = new TestCase((Priority)_random.Next(0, 5), "test", "test", (Status)_random.Next(0, 5),
                tempSteps);
            return tempTestCase;
        }

        public static Bug CreateBug()
        {
            var tempBug = new Bug();
            while (true)
            {
                Console.WriteLine("Enter priority:\n1 - Low\n2 - Medium\n3 - High\n4 - Critical");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    if (value is < 4 and >= 0)
                    {
                        tempBug.Priority = (Priority)value;
                        break;
                    }
                }

                Console.WriteLine("Incorrect priority");
            }

            Console.WriteLine("Enter Summary:");
            tempBug.Summary = Console.ReadLine();
            Console.WriteLine("Enter Preconditions");
            tempBug.Preconditions = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Enter Status:\n1 - New\n2 - InProgress\n3 - Failed\n4 - Done");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    if (value is < 4 and >= 0)
                    {
                        tempBug.Status = (Status)value;
                        break;
                    }
                }

                Console.WriteLine("Incorrect status");
            }

            while (true)
            {
                Console.WriteLine("Enter test case ID:");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    tempBug.TestCaseId = value;
                    break;
                }

                Console.WriteLine("Incorrect test case ID");
            }

            while (true)
            {
                Console.WriteLine("Enter test case step number:");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    tempBug.StepNumber = value;
                    break;
                }

                Console.WriteLine("Incorrect test case step number");
            }

            Console.WriteLine("Enter actual result:");
            tempBug.ActualResult = Console.ReadLine();
            Console.WriteLine("Enter expected result:");
            tempBug.ExpectedResult = Console.ReadLine();
            return tempBug;
        }

        public static TestCase CreateTestCase()
        {
            var steps = new List<Step>();
            Priority priority = Priority.Low;
            string summary = "";
            Status status = Status.New;
            string preconditions = "";
            
            while (true)
            {
                Console.WriteLine("Enter priority:\n1 - Low\n2 - Medium\n3 - High\n4 - Critical");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    if (value is < 4 and >= 0)
                    {
                        priority = (Priority)value;
                        break;
                    }
                }

                Console.WriteLine("Incorrect priority");
            }

            Console.WriteLine("Enter Summary:");
            summary = Console.ReadLine();
            Console.WriteLine("Enter Preconditions");
            preconditions = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Enter Status:\n1 - New\n2 - InProgress\n3 - Failed\n4 - Done");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    if (value is < 4 and >= 0)
                    {
                        status = (Status)value;
                        break;
                    }
                }

                Console.WriteLine("Incorrect status");
            }

            while (true)
            {
                var stepNumber = 0;
                var tempAction = "";
                var tempResult = "";
                

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Test steps wizard:\n1. Add test step\n2.Continue");
                    
                    if (int.TryParse(Console.ReadLine(), out var value))
                    {
                        switch (value)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Specify the Action:");
                                tempAction = Console.ReadLine();
                                Console.WriteLine("Specify the result");
                                tempResult = Console.ReadLine();
                                steps.Add(new Step(stepNumber++, tempAction, tempResult));
                                break;
                            case 2:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect imput, press any button to continue");
                    }

                    Console.WriteLine("Add more steps? Y/Any char");
                    if (Console.ReadLine() == "y")
                    {
                        continue;
                    }

                    break;

                }

                var tempTestCase = new TestCase(priority, summary, preconditions, status, steps);
                return tempTestCase;
            }
        }
    }
}