using System;
using System.Collections.Generic;

namespace HomeWork2
{
    public class TestCase : Issue
    {
        private List<Step> _steps = new List<Step>();
        
        private string[] _testStepsWizard = {"Add test step", "Continue"};

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
                    var value = Actions.Choose(_testStepsWizard);
                    switch (value)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Specify the Action:");
                                tempAction = Console.ReadLine();
                                Console.WriteLine("Specify the result");
                                tempResult = Console.ReadLine();
                                steps.Add(new Step(stepNumber++, tempAction, tempResult));
                                continue;
                            case 2:
                                break;
                        }
                    break;
                }

                Console.WriteLine("Add more steps? Y/Any char");
                var tempValue = Actions.Choose("Yes", "Mo");
                if (tempValue == 1)
                {
                    continue;
                }

                break;
            }

            AddSteps(steps);
        }

        public void AddSteps(IEnumerable<Step> steps)
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