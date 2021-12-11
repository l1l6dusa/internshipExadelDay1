using System;

namespace HomeWork2
{
    public class Bug : Issue
    {
        private int _testCaseId;
        private int _stepNumber;
        private string _actualResult;
        private string _expectedResult;

        #region Unused properties
        public int TestCaseId
        {
            get => _testCaseId;
            set => _testCaseId = value;
        }
        public int StepNumber
        {
            get => _stepNumber;
            set => _stepNumber = value;
        }
        public string ActualResult
        {
            get => _actualResult;
            set => _actualResult = value;
        }
        public string ExpectedResult
        {
            get => _expectedResult;
            set => _expectedResult = value;
        }
        #endregion

        public Bug(Priority priority, string summary, string preconditions, Status status, int testCaseId, int stepNumber, string actualResult, string expectedResult) : base(priority, summary, preconditions, status)
        {
            _testCaseId = testCaseId;
            _stepNumber = stepNumber;
            _actualResult = actualResult;
            _expectedResult = expectedResult;
        }

        public Bug() : base(Priority.Low, "", "", Status.New)
        {
            
        }

        public void Set()
        {
            base.Set();
            while (true)
            {
                Console.WriteLine("Enter test case ID:");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    _testCaseId = value;
                    break;
                }

                Console.WriteLine("Incorrect test case ID");
            }

            while (true)
            {
                Console.WriteLine("Enter test case step number:");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    _stepNumber = value;
                    break;
                }

                Console.WriteLine("Incorrect test case step number");
            }

            Console.WriteLine("Enter actual result:");
           _actualResult = Console.ReadLine();
            Console.WriteLine("Enter expected result:");
            _expectedResult = Console.ReadLine();
        }

        public override void Get()
        {
            base.Get();
            Console.WriteLine($"Test Case ID: {_testCaseId}\n" +
                              $"Step Number: {_stepNumber}\n" +
                              $"Actual Result: {_actualResult}\n" +
                              $"Expected Result: {_expectedResult}"
                              );
        }

        public void Fill(Priority priority, Status status, string summary, string preconditions, int testCaseId, int stepNumber, string actualResult, string expectedResult)
        {
            base.Fill(priority, status, summary, preconditions);
            _testCaseId = testCaseId;
            _stepNumber = stepNumber;
            _actualResult = actualResult;
            _expectedResult = expectedResult;

        }
    }
}