namespace HomeWork2
{
    public class Step
    {
        private int _stepNumber;
        private string _action;
        private string _result;

        public string Action => _action;
        public string Result => _result;

        public Step(int stepNumber, string action = "", string result = "")
        {
            _stepNumber = stepNumber;
            _action = action;
            _result = result;
        }
    }
}