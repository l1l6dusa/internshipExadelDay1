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


        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Test Case ID: {_testCaseId}\n" +
                              $"Step Number: {_stepNumber}\n" +
                              $"Actual Result: {_actualResult}\n" +
                              $"Expected Result: {_expectedResult}"
                              );
        }
        
        
        
    }
}