using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    public static class IenumerableExtentions
    {
        public static IEnumerable<T> SortByPriority<T>(this IEnumerable<T> collection, bool ascending) where T: Issue
        {
            return (@ascending ? collection.OrderBy(x => x.Priority) : collection.OrderByDescending(x => x.Priority));
        }
        
        public static IEnumerable<T> SortById<T>(this IEnumerable<T> collection, bool ascending) where T: Issue
        {
            return @ascending ? collection.OrderBy(x => x.Id) : collection.OrderByDescending(x => x.Id);
        }
        
        public static IEnumerable<T> SortByCreatedDate<T>(this IEnumerable<T> collection, bool ascending) where T: Issue
        {
            return @ascending ? collection.OrderBy(x => x.CreationDate) : collection.OrderByDescending(x => x.CreationDate);
        }
        
        public static IEnumerable<T> SortBySummary<T>(this IEnumerable<T> collection, bool ascending) where T: Issue
        {
            return @ascending ? collection.OrderBy(x => x.Summary) : collection.OrderByDescending(x => x.Summary);
        }
        
        public static IEnumerable<T> SortByStatus<T>(this IEnumerable<T> collection, bool ascending) where T: Issue
        {
            return @ascending ? collection.OrderBy(x => x.Status) : collection.OrderByDescending(x => x.Status);
        }

        public static IEnumerable<T> FilterByPriority<T>(this IEnumerable<T> collection, Priority priority) where T: Issue
        {
            return collection.ToList().FindAll(x => x.Priority == priority);
        }
        
        public static IEnumerable<T> FilterByStatus<T>(this IEnumerable<T> collection, Status status) where T: Issue
        {
            return collection.ToList().FindAll(x => x.Status == status);
        }
    }
}