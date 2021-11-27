using System;

namespace ConsoleApp1
{
    public class BugBuilder
    {
        public Bug CreateBug()
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
    }
}