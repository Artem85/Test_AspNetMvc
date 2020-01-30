using AspNetMvc.Models;
using Common.Repositories;
using Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvc.Infrastructure
{
    public class DataContext
    {
        public static IRepository<TestResult> Repository = new Repository<TestResult>(new List<TestResult>());

        static DataContext()
        {
            CreateTestData();
        }

        private static void CreateTestData()
        {
            Repository.Add(new TestResult()
            {
                Id = 1,
                Name = "John Deer",
                Test = "Mathematic",
                Date = "2020-01-10",
                Mark = 5
            });
            Repository.Add(new TestResult()
            {
                Id = 2,
                Name = "Robert Miles",
                Test = "Mathematic",
                Date = "2020-01-10",
                Mark = 4
            });
            Repository.Add(new TestResult()
            {
                Id = 3,
                Name = "John Deer",
                Test = "Physics",
                Date = "2020-01-12",
                Mark = 5
            });
            Repository.Add(new TestResult()
            {
                Id = 4,
                Name = "Robert Miles",
                Test = "Physics",
                Date = "2020-01-12",
                Mark = 3
            });
            Repository.Add(new TestResult()
            {
                Id = 5,
                Name = "John Deer",
                Test = "Chemistry",
                Date = "2020-01-15",
                Mark = 5
            });
            Repository.Add(new TestResult()
            {
                Id = 6,
                Name = "Robert Miles",
                Test = "Chemistry",
                Date = "2020-01-15",
                Mark = 4
            });
        }
    }
}