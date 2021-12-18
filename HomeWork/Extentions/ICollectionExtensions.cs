using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HomeWork2
{
    public static class ICollectionExtensions
    {
        private static readonly string[] sortingOrder = { "Descending", "Ascending" };
        private static readonly string[] _displayIssuesWizard = { "Add Sorting", "Add Filtering", "Proceed to issues" };

        private static readonly string[] sortingWizardItems =
        {
            "Sort Py Priority", "Sort By Id", "Sort by Created Date",
            "Sort By Summary", "Sort By Status"
        };

        private static readonly string[] filteringOptionsItems = { "Filter By Priority", "Filter By Status" };
        private static readonly string[] filteringPriorityItems = { "Low", "Medium", "High", "Critical" };
        private static readonly string[] filteringStatusItems = { "New", "InProgress", "Failed", "Done" };

        public static void AddIssue<T>(this ICollection<T> issues) where T : Issue, new()
        {
            var tempIssue = new T();
            tempIssue.Set();
            issues.Add(tempIssue);
        }

        public static void ShowAll<T>(this ICollection<T> issues) where T : Issue
        {
            bool ascending = false;
            var result = Helper.Choose("Select option:", _displayIssuesWizard);
            switch (result)
            {
                case 1:
                    SelectSort(issues);
                    break;
                case 2:

                    SelectFilter(issues);
                    break;
                case 3:
                    issues.DisplayIssues();
                    break;
            }
        }

        public static void ShowIssueById<T>(this ICollection<T> issues, long id) where T : Issue
        {
            if (id < 0 || id >= issues.Count)
            {
                throw new InvalidInputException("Incorrect input, press any button to continue");
            }

            try
            {
                issues.ToList().Find(x => x.Id == id).Get();
            }
            catch (Exception e)
            {
                Console.WriteLine("Issue doesn't exist.");
                
            }
            
            Console.WriteLine("Click any key to continue...");
            Console.ReadLine();
        }

        public static void RunTestCaseById(this ICollection<TestCase> testCases,ICollection<Bug> bugs, long id)
        {
            if (id < 0 || id >= testCases.Count)
            {
                throw new InvalidInputException("Incorrect input, press any button to continue");
            }
            var exitLoop = false;
            var testCase = testCases.FirstOrDefault(x => x.Id == id);
            foreach (var step in testCase.Steps)
            {
                Console.Clear();
                if(exitLoop)
                {
                    break;
                }
                Console.WriteLine("Press Y/N to mark the step complete/failed:");
                step.Get();
                var input = Console.ReadLine();
                
                switch (input.ToUpper())
                {
                    case "Y":
                        continue;
                    case "N":
                        Console.WriteLine("Select priority:");
                        var priority = (Priority)Helper.ChooseEnumOptions<Priority>();
                        Console.WriteLine("Specify Actual result:");
                        var actualResult = Console.ReadLine();
                        bugs.Add(new Bug(
                            priority,
                            testCase.Summary,
                            testCase.Preconditions,
                            Status.New,
                            testCase.Id,
                            step.StepNumber,
                            step.Result,
                            actualResult
                            )
                        );
                        testCase.Status = Status.Failed;
                        exitLoop = true;
                        continue;
                    default:
                        throw new InvalidInputException("Incorrect input, press any button to continue");
                }
                
            }

            if (exitLoop == false)
            {
                testCase.Status = Status.Done;
                Console.WriteLine("Test Case is marked Done. Click any button to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Test Case is marked Failed. Click any button to continue...");
                Console.ReadLine();
            }

        }

        public static void DeleteIssueById<T>(this ICollection<T> issues, long id) where T : Issue
        {
            if (id < 0 || id >= issues.Count)
            {
                throw new InvalidInputException("Incorrect input, press any button to continue");
            }

            try
            {
                var tempItem = issues.ToList().Find(x => x.Id == id);
                issues.Remove(tempItem);
                Console.WriteLine($"Item with ID {id} is deleted. Click any button to continue... ");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Issue doesn't exist");
            }
            
            
        }

        public static void ChangeBugStatusById(this ICollection<Bug> bugs, ICollection<TestCase> testCases, long id)
        {
            if (id < 0 || id >= bugs.Count)
            {
                throw new InvalidInputException("Incorrect input, press any button to continue");
            }

            try
            {
                var tempBug = bugs.ToList().Find(x => x.TestCaseId == id);
                var tempTestCase = testCases.ToList().Find(x=>x.Id == tempBug.TestCaseId);
                Console.WriteLine("Select status:");
                var statusValue = (Status)Helper.ChooseEnumOptions<Status>();
            
                tempBug.Status = statusValue;
                if (statusValue == Status.Done)
                {
                    tempTestCase.Status = Status.Done;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Issue doesn't exist");
                throw;
            }
            
            
        } 
        private static void DisplayIssues<T>(this ICollection<T> issues) where T : Issue
        {
            Console.Clear();
            foreach (var issue in issues)
            {
                issue.Get();

            }

            Console.ReadLine();
        }

        private static void SelectSort<T>(ICollection<T> list) where T : Issue
        {
            bool ascending = false;
            Console.Clear();
            var value = Helper.Choose("Select sorting option: ", sortingWizardItems);
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
                    DisplayIssues(list.SortBySummary(ascending).ToList());
                    break;
                case 5:
                    value = Helper.Choose(sortingOrder);
                    ascending = value != 1;
                    DisplayIssues(list.SortByStatus(ascending));
                    break;
            }

            Console.WriteLine("Click any key to continue...");
            Console.ReadLine();
        }

        private static void SelectFilter<T>(ICollection<T> list) where T : Issue
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

        public static ICollection<T> SortByPriority<T>(this ICollection<T> collection, bool ascending) where T : Issue
        {
            return (@ascending ? collection.OrderBy(x => x.Priority) : collection.OrderByDescending(x => x.Priority))
                .ToList();
        }

        public static ICollection<T> SortById<T>(this ICollection<T> collection, bool ascending) where T : Issue
        {
            return @ascending
                ? collection.OrderBy(x => x.Id).ToList()
                : collection.OrderByDescending(x => x.Id).ToList();
        }

        public static ICollection<T> SortByCreatedDate<T>(this ICollection<T> collection, bool ascending)
            where T : Issue
        {
            return @ascending
                ? collection.OrderBy(x => x.CreationDate).ToList()
                : collection.OrderByDescending(x => x.CreationDate).ToList();
        }

        public static ICollection<T> SortBySummary<T>(this ICollection<T> collection, bool ascending) where T : Issue
        {
            return @ascending
                ? collection.OrderBy(x => x.Summary).ToList()
                : collection.OrderByDescending(x => x.Summary).ToList();
        }

        public static ICollection<T> SortByStatus<T>(this ICollection<T> collection, bool ascending) where T : Issue
        {
            return @ascending
                ? collection.OrderBy(x => x.Status).ToList()
                : collection.OrderByDescending(x => x.Status).ToList();
        }

        public static ICollection<T> FilterByPriority<T>(this ICollection<T> collection, Priority priority)
            where T : Issue
        {
            try
            {
                var filteredCollection = collection.ToList().FindAll(x => x.Priority == priority);
                return filteredCollection;
            }
            catch (Exception e)
            {
                Console.WriteLine("No issues found.");
                throw;
            }

            
        }

        public static ICollection<T> FilterByStatus<T>(this ICollection<T> collection, Status status) where T : Issue
        {
            try
            {
                var filteredCollection = collection.ToList().FindAll(x => x.Status == status);
                return filteredCollection;
            }
            catch (Exception e)
            {
                Console.WriteLine("No issues found.");
                throw;
            }
            

        }
    }
}