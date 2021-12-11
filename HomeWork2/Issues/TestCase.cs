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

        public TestCase():base(Priority.Low, "", "", Status.New)
        {
            
        }

        public override void Get()
        {
            base.Get();
            foreach (var step in _steps)
            {
                Console.WriteLine("Action: " + step.Action + "\nResult: " + step.Result);
            }
        }

        public override void Set()
        {
            var steps = new List<Step>();
            base.Set();
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

                Fill(steps);
            }
        }

        private void Fill(IEnumerable<Step> steps)
        {
            _steps.AddRange(steps);
        }
        
        private void Fill(Priority priority, Status status, string summary, string preconditions,IEnumerable<Step> steps)
        {
            base.Fill(priority, status, summary, preconditions);
            _steps.AddRange(steps);

        }
        
    }
}