using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace HomeWork2
{
    public class Application
    {
        private bool _isRunning = true;
        Random random = new Random();
        List<Bug> _bugList = new ();
        List<TestCase> _testCaseList = new ();

        private readonly string[] _newMenu =
        {
            "Create a test case",
            "Show a test case by id",
            "Show all test cases",
            "Delete test case by id",
            "Run a test case by id",
            "Show a bug by id",
            "Show all bugs",
            "Change a bug status by id",
            "Delete a bug ",
            "Exit"
        };

        private readonly string[] _menuWizardItems = {"Create Test case", "Create bug", "Remove the test case", 
            "Remove bug", "Seed test cases", "Seed bug tickets", "Show issues", "Show filtered issues"};
        private readonly string[] sortingWizardItems = {"Sort Py Priority", "Sort By Id", "Sort by Created Date", 
            "Sort By Summary", "Sort By Status"};
        private readonly string[] filteringOptionsItems = {"Filter By Priority", "Filter By Status"};
        private readonly string[] filteringPriorityItems = { "Low", "Medium", "High", "Critical" };
        private readonly string[] filteringStatusItems = { "New", "InProgress", "Failed", "Done"};
        private readonly string[] sortingOrder = { "Descending", "Ascending" };

        public void Run()
        {
            while (_isRunning)
            {
                try
                {
                    Console.Clear();
                    var value = Helper.Choose("Select action:", _newMenu);
                    
                        switch (value)
                    {
                        case 1: //done
                           _testCaseList.AddIssue();
                            continue;
                        case 2:
                            ShowById(_testCaseList);
                            continue;
                        case 3:
                            _testCaseList.ShowAll();
                            continue;
                        case 4:
                            RemoveById(_testCaseList);
                            continue;
                        case 5:
                            RunTestCaseById();
                            continue;
                        case 6:
                            ShowById(_bugList);
                            continue;
                        case 7:
                            _bugList.ShowAll();
                            continue;
                        case 8:
                            ChangeBugStatusById();
                            continue;
                        case 9:
                            RemoveById(_bugList);
                            continue;
                        case 10:
                            _isRunning = false;
                            break;
                    }

                }
                catch(InvalidInputException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private void Remove(List<Issue> list, string issueType)
        {
            if (list.Count > 0)
            {
                foreach (var testcase in list)
                {
                    Console.WriteLine($"{issueType.Capitalize()} ID: {testcase.Id} Summary: {testcase.Summary} Status: {testcase.Status}");
                }
                Console.WriteLine($"Select the ID of the {issueType.ToLower()} which shall be removed: ");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    if (_testCaseList.Find(x=>x.Id == value) != null)
                    {
                        _testCaseList.RemoveAll(x => x.Id == value);
                        Console.WriteLine($"{issueType.Capitalize()} with ID {value} is removed, press any button to continue");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, press any button to continue");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input, press any button to continue");
                }
            }
        }

        private void ShowById<T>(ICollection<T> collection) where T : Issue
        {
            Console.Clear();
            Console.WriteLine("Choose ID:");
            if (long.TryParse(Console.ReadLine(), out var result))
            {
                collection.ShowIssueById(result);
            }else
            {
                throw new InvalidInputException("Invalid Input");
            }
           
        }

        private void RemoveById<T>(ICollection<T> collection)where T : Issue
        {
            Console.WriteLine("Choose ID:");
            if (long.TryParse(Console.ReadLine(), out var result))
            {
                collection.DeleteIssueById(result);
            }else
            {
                throw new InvalidInputException("Invalid Input");
            }
        }

        private void RunTestCaseById()
        {
            Console.WriteLine("Choose ID:");
            if (long.TryParse(Console.ReadLine(), out var result))
            {
                _testCaseList.RunTestCaseById(_bugList, result);
            }else
            {
                throw new InvalidInputException("Invalid Input");
            }
        }

        private void ChangeBugStatusById()
        {
            Console.WriteLine("Choose ID:");
            if (long.TryParse(Console.ReadLine(), out var result))
            {
                _bugList.ChangeBugStatusById(_testCaseList, result);
            }else
            {
                throw new InvalidInputException("Invalid Input");
            }
        }

    }
}