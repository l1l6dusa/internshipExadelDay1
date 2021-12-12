using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace HomeWork2
{
    public class Runner
    {
        Random random = new Random();
        List<Issue> _bugList = new ();
        List<Issue> _testCaseList = new ();
        private readonly string[] _menuWizardItems = {"Create Test case", "Create bug", "Remove the test case", 
            "Remove bug", "Seed test cases", "Seed bug tickets", "Show issues", "Show filtered issues"};
        private readonly string[] sortingWizardItems = {"Sort Py Priority", "Sort By Id", "Sort by Created Date", 
            "Sort By Summary", "Sort By Status"};
        private readonly string[] filteringOptionsItems = {"Filter By Priority", "Filter By Status"};
        private readonly string[] filteringPriorityItems = { "Low", "Medium", "High", "Critical" };
        private readonly string[] filteringStatusItems = { "New", "InProgress", "Failed", "Done"};
        private readonly string[] sortingOrder = { "Descending", "Ascending" };
        
        public void Execute()
        {
            
            while (true)
            {
                Console.Clear();
                if (_bugList.Count>0)
                {
                        Console.WriteLine($"Current bug quantity: {_bugList.Count}");
                }

                if (_testCaseList.Count > 0)
                {
                    Console.WriteLine($"Current test cases quantity: {_testCaseList.Count}");
                }

                Console.WriteLine();
                var value = Helper.Choose("Select action:", _menuWizardItems);
                switch (value)
                    {
                        case 1:
                            var tempTC = new TestCase();
                            tempTC.Set();
                            _testCaseList.Add(tempTC);
                            continue;
                        case 2:
                            var tempBug = new Bug();
                            tempBug.Set();
                            _testCaseList.Add(tempBug);
                            continue;
                        case 3:
                            Remove(_testCaseList, "test case");
                            Console.ReadKey();
                            continue;
                        case 4:
                            Remove(_bugList, "bug");
                            Console.ReadKey();
                            continue;
                        case 5:
                            _testCaseList.AddRange(IssueBuilder.SeedTestCases(5));
                            Console.WriteLine("5 test cases are added");
                            continue;
                        case 6:
                            _bugList.AddRange(IssueBuilder.SeedBugs(5));
                            Console.WriteLine(("5 bugs are created"));
                            continue;
                        case 7:
                            Sort();
                            continue;
                        case 8:
                           Filter();
                           continue;
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

        private void Sort()
        {
            Console.WriteLine();
            Console.Clear();
            var value = Helper.Choose("Select type of issues:", new []{"Bug", "Test Case"});
            if (value == 1)
            {
                SelectSort(_bugList);
            }
            else
            {
                SelectSort(_testCaseList);
            }
        }

        private void DisplayIssues(IEnumerable<Issue> issues)
        {
            Console.Clear();
            foreach (var issue in issues)
            {
                issue.Get();
                
            }
            Console.ReadLine();
        }
        


        private void Filter()
        {
            Console.Clear();
            var value = Helper.Choose("Select type:", new[]{"Bug", "Test Case" });

            SelectFilter(value == 1 ? _bugList : _testCaseList);
        }

        private void SelectFilter(List<Issue> list)
        {
            Console.Clear();
            var value = Helper.Choose("Select Filtering Options:", filteringOptionsItems);
            if (value == 1)
            {
                Console.Clear();
                value = Helper.Choose("Select filter:", filteringPriorityItems);
                DisplayIssues(list.FilterByPriority((Priority)value));
            }
            else
            {
                Console.Clear();
                value = Helper.Choose("Select filter:", filteringStatusItems);
                DisplayIssues(list.FilterByStatus((Status)value));
            }
        }

        private void SelectSort(List<Issue> list)
        {
            bool ascending = default;
            Console.Clear();
            var value = Helper.Choose("Select sorting option: ",sortingWizardItems);
            Console.Clear();
            Console.WriteLine("Descending/Ascending?");
            switch (value)
            {
                case 1:
                    value = Helper.Choose(sortingOrder);
                    ascending = value != 1;
                    DisplayIssues(list.SortByPriority(ascending));
                    break;
                case 2:
                    value = Helper.Choose(sortingOrder);
                    ascending = value != 1;
                    DisplayIssues(list.SortById(ascending));
                    break;
                case 3:
                    value = Helper.Choose(sortingOrder);
                    ascending = value != 1;
                    DisplayIssues(list.SortByCreatedDate(ascending));
                    break;
                case 4:
                    value = Helper.Choose(sortingOrder);
                    ascending = value != 1;
                    DisplayIssues(list.SortBySummary(ascending));
                    break;
                case 5:
                    value = Helper.Choose(sortingOrder);
                    ascending = value != 1;
                    DisplayIssues(list.SortByStatus(ascending));
                    break;
            }
        }
        
    }
}