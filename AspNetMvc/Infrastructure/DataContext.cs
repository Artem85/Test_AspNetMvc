using AspNetMvc.Models;
using Common.Events;
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
            Repository.ItemUpdate += Repository_ItemUpdate;
            CreateTestData();
        }

        private static void Repository_ItemUpdate(object sender, EntityUpdateEventArgs e)
        {
            TestResult obj = e.EntityObject as TestResult;
            TestResult newObj = e.NewEntityObject as TestResult;

            obj.Name = newObj.Name;
            obj.Test = newObj.Test;
            obj.Date = newObj.Date;
            obj.Mark = newObj.Mark;
        }

        private static void CreateTestData()
        {
            Repository.Add(new TestResult()
            {
                Id = 1,
                Name = "John Deer",
                Test = "Mathematic",
                Date = new DateTime(2020, 1, 10),
                Mark = 5
            });
            Repository.Add(new TestResult()
            {
                Id = 2,
                Name = "Robert Miles",
                Test = "Mathematic",
                Date = new DateTime(2020, 1, 10),
                Mark = 4
            });
            Repository.Add(new TestResult()
            {
                Id = 3,
                Name = "John Deer",
                Test = "Physics",
                Date = new DateTime(2020, 1, 12),
                Mark = 5
            });
            Repository.Add(new TestResult()
            {
                Id = 4,
                Name = "Robert Miles",
                Test = "Physics",
                Date = new DateTime(2020, 1, 12),
                Mark = 3
            });
            Repository.Add(new TestResult()
            {
                Id = 5,
                Name = "John Deer",
                Test = "Chemistry",
                Date = new DateTime(2020, 1, 15),
                Mark = 5
            });
            Repository.Add(new TestResult()
            {
                Id = 6,
                Name = "Robert Miles",
                Test = "Chemistry",
                Date = new DateTime(2020, 1, 15),
                Mark = 4
            });
        }
    }
}