using System;

namespace HomeWork2
{
    public abstract class Issue : IIssue

    { 
    private static int s_idCounter;


    #region Properties

    public long Id { get; }

    public DateTime CreationDate { get; }

    public Priority Priority { get; set; }

    public string Summary { get; set; }

    public string Preconditions { get; set; }

    public Status Status { get; set; }

    #endregion


    protected Issue(Priority priority, string summary, string preconditions, Status status) : this()
    {

        Priority = priority;
        Summary = summary;
        Preconditions = preconditions;
        Status = status;
    }

    private Issue()
    {
        Id = s_idCounter++;
        CreationDate = DateTime.Now;
    }

    public virtual void Get()
    {
        Console.WriteLine($"ID: {Id}\n" +
                          $"Created At: {CreationDate}\n" +
                          $"Priority: {Priority.ToString()}\n" +
                          $"Status: {Status.ToString()}\n" +
                          $"Summary: {Summary}\n" +
                          $"Preconditions: {Preconditions}\n"
        );
    }

    protected void Fill(Priority priority, Status status, string summary, string preconditions)
    {
        Priority = priority;
        Summary = summary;
        Preconditions = preconditions;
        Status = status;
    }

    public virtual void Set()
    {
        Priority priority = default;
        string summary = default;
        Status status = default;
        string preconditions = default;
        priority = (Priority) Helper.ChooseEnumOptions<Priority>();
        Console.WriteLine("Enter Summary:");
        summary = Console.ReadLine();
        Console.WriteLine("Enter Preconditions");
        preconditions = Console.ReadLine();
        status = (Status)Helper.ChooseEnumOptions<Status>();
        Fill(priority, status, summary, preconditions);
    }
    
    }
}