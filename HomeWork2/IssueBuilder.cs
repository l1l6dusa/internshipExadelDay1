using System;
using System.Collections.Generic;

namespace HomeWork2
{
    public static class IssueBuilder
    {
        private static Random _random = new Random();
        public static Bug CreateBug()
        {
            var tempBug = new Bug((Priority)_random.Next(0, 5), "test", "test", (Status)_random.Next(0, 5),
                _random.Next(0, 11), _random.Next(0, 11), "test", "test");
            return tempBug;
        }


        public static TestCase CreateTestCase()
        {
            List<Step> tempSteps = new List<Step>();
            for (var i = 0; i < _random.Next(1,6); i++)
            {
                tempSteps.Add(new Step(i, $"{i} action", $"{i} result"));
            }

            var tempTestCase = new TestCase((Priority)_random.Next(0, 5), "test", "test", (Status)_random.Next(0,5), tempSteps);
            return tempTestCase;
        }
    }
}