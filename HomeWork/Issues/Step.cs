using System;

namespace HomeWork2
{
    public class Step
    {
        public int StepNumber { get; }

        public string Action { get; private set; }

        public string Result { get; private set; }

        public Step(int stepNumber, string action = "", string result = "")
        {
            StepNumber = stepNumber;
            Action = action;
            Result = result;
        }
        
        
        public void Set(string action, string result)
        {
            Action = action;
            Result = result;

        }

        public void Get()
        {
            Console.WriteLine($"#{StepNumber}\n" +
                              $"Action: {Action}\n" +
                              $"Expected result: {Result}");
        }
    }
}