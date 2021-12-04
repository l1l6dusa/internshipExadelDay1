using System;
using System.Collections.Generic;

namespace HomeWork2
{
    public class TestCase : Issue
    {
        private List<Step> _steps;

        #region Unused Properties
        public IEnumerable<Step> Steps => _steps;
        #endregion

        public TestCase(Priority priority, string summary, string preconditions, Status status, List<Step> steps) : base(priority, summary, preconditions, status)
        {
            _steps = steps;
        }
        

        public override void Display()
        {
            base.Display();
            foreach (var step in _steps)
            {
                Console.WriteLine("Action: " + step.Action + "\nResult: " + step.Result);
            }
        }

    }
}