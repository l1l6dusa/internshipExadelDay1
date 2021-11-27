using System;

namespace ConsoleApp1
{
    public enum Priority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum Status
    {
        New,
        InProgress,
        Failed,
        Done
    }
    
    public class Bug
    {
        private static int s_idCounter;
        private readonly int _id;
        private readonly DateTime _creationDate;
        private Priority _priority;
        private string _summary;
        private string _preconditions;
        private Status _status;
        private int _testCaseId;
        private int _stepNumber;
        private string _actualResult;
        private string _expectedResult;

        public int Id => _id;

        public DateTime CreationDate => _creationDate;

        public Priority Priority
        {
            get => _priority;
            set => _priority = value;
        }

        public string Summary
        {
            get => _summary;
            set => _summary = value;
        }

        public string Preconditions
        {
            get => _preconditions;
            set => _preconditions = value;
        }

        public Status Status
        {
            get => _status;
            set => _status = value;
        }

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

        public Bug(Priority priority, string summary, string preconditions, Status status, int testCaseId, int stepNumber, string actualResult, string expectedResult)
        {
            _id = s_idCounter++;
            _creationDate = DateTime.Now;
            _priority = priority;
            _summary = summary;
            _preconditions = preconditions;
            _status = status;
            _testCaseId = testCaseId;
            _stepNumber = stepNumber;
            _actualResult = actualResult;
            _expectedResult = expectedResult;
        }

        public Bug()
        {
            _id = s_idCounter++;
            _creationDate = DateTime.Now;
        }
        
        
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {_id}\n" +
                              $"Created At: {_creationDate}\n" +
                              $"Priority: {_priority.ToString()}\n" +
                              $"Summary: {_summary}\n" +
                              $"Preconditions: {_preconditions}\n" +
                              $"Status: {_status.ToString()}\n" +
                              $"Test Case ID: {_testCaseId}\n" +
                              $"Step Number: {_stepNumber}\n" +
                              $"Actual Result: {_actualResult}\n" +
                              $"Expected Result: {_expectedResult}");
        }
    }
}
