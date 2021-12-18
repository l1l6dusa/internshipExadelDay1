using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2
{
    public static class IssueBuilder
    {
        private static readonly Random _random = new Random();
        private static string[] beginning =
        {
            "navbar", "spinner", "report", "login", "user", "element", "developer"
        };
        private static string[] verbConjunction = 
        {
            "shows", "is", "loads", "represents", "blocked by", "disables",
            "clicks"
        };
        private static string[] ending =
        {
            "nothing", "incorrect info", "empty", "depressed", "ad banner", 
            "pron site ad", "scooby-doo"
        };
        private static string[] testCaseBeginning =
        {
            "Check that", "Verify that", "Make Sure that", "See that", "Observe that"
        };
        
        private static string[] TSAction =
        {
            "Hover over an a field", "Login", "Click 'Pay'", "Click Back", "Expand the menu"
        };

        private static string[] TSResult =
        {
            "Menu expanded", "Confirmation banner is shown", "Warning is shown", "An error is shown",
            "New page is opened", "universe collapsed"
        };

        private static string BuildCaseName()
        {
            return new StringBuilder()
                .Append(testCaseBeginning[_random.Next(0, testCaseBeginning.Length - 1)]).Append(' ')
                .Append(beginning[_random.Next(0, testCaseBeginning.Length - 1)]).Append(' ')
                .Append(verbConjunction[_random.Next(0, verbConjunction.Length - 1)]).Append(' ')
                .Append(ending[_random.Next(0, ending.Length - 1)]).ToString();
        } 
        private static string BuildBugName()
        {
            return new StringBuilder()
                .Append(beginning[_random.Next(0, testCaseBeginning.Length - 1)]).Append(' ')
                .Append(verbConjunction[_random.Next(0, verbConjunction.Length - 1)]).Append(' ')
                .Append(ending[_random.Next(0, ending.Length - 1)]).ToString();
        }

        public static List<Bug> SeedBugs(int qty)
        {
            var list = new List<Bug>();
            
            for (int i = 0; i < qty; i++)
            {
                var temp = new Bug()
                {
                    Summary = BuildBugName(),
                    Preconditions = BuildCaseName(),
                    Priority = (Priority)_random.Next(1, 5),
                    Status = (Status)_random.Next(1, 5),
                    ActualResult = BuildBugName(),
                    ExpectedResult = BuildBugName(),
                    StepNumber = _random.Next(0,10),
                    TestCaseId = _random.Next(0,10)
                };
                list.Add(temp);
            }
            return list;
        }
        
        public static IEnumerable<TestCase> SeedTestCases(int qty)
        {
            var list = new List<TestCase>();

            for (int i = 0; i < qty; i++)
            {
                var tempTSList = new List<Step>();
                var testCase = new TestCase()
                {
                    Summary = BuildCaseName(),
                    Preconditions = BuildCaseName(),
                    Priority = (Priority)_random.Next(0, 5),
                    Status = (Status)_random.Next(0, 5),
                };
                var numberOfSteps = _random.Next(1, 5);
                for (var j = 0; j < numberOfSteps; j++)
                {
                    var action = TSAction[_random.Next(0, TSAction.Length)];
                    var result = TSResult[_random.Next(0, TSResult.Length)];
                    var tempStep = new Step(j, action, result);
                    tempTSList.Add(tempStep);
                }
                testCase.AddSteps(tempTSList);
                list.Add(testCase);
            }

            return list;
        }
    }
}