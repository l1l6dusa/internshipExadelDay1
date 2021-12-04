using System;

namespace HomeWork2
{
    public abstract class Issue
    {
        private static int s_idCounter;
        private readonly int _id;
        private readonly DateTime _creationDate;
        private Priority _priority;
        private string _summary;
        private string _preconditions;
        private Status _status;
    

        #region Unused properties

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

        #endregion
        
        
        protected Issue(Priority priority, string summary, string preconditions, Status status) : this()
        {
            
            _priority = priority;
            _summary = summary;
            _preconditions = preconditions;
            _status = status;
        }

        private Issue()
        {
            _id = s_idCounter++;
            _creationDate = DateTime.Now;
        }

        public virtual void Display()
        {
            Console.WriteLine($"ID: {_id}\n" +
                              $"Created At: {_creationDate}\n" +
                              $"Priority: {_priority.ToString()}\n" +
                              $"Status: {_status.ToString()}\n" +
                              $"Summary: {_summary}\n" +
                              $"Preconditions: {_preconditions}\n"
                              );
        }

        protected void Fill(Priority priority, Status status, string summary, string preconditions)
        {
            _priority = priority;
            _summary = summary;
            _preconditions = preconditions;
            _status = status;
        }
    }
}