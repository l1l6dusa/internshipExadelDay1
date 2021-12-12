namespace HomeWork2
{
    public class Step
    {
        private int _stepNumber;

        public string Action { get; }

        public string Result { get; }

        public Step(int stepNumber, string action = "", string result = "")
        {
            _stepNumber = stepNumber;
            Action = action;
            Result = result;
        }
    }
}