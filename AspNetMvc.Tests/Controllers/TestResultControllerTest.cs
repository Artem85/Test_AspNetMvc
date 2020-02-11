using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestResults = AspNetMvc.Models.TestResult;
using System.Collections.Generic;
using Moq;
using Common.Repositories.Interfaces;
using AspNetMvc.Controllers;
using System.Collections;
using System.Linq;

namespace AspNetMvc.Tests.Controllers
{
    [TestClass]
    public class TestResultControllerTest
    {
        readonly ICollection<TestResults> collection =
               new List<TestResults> {
                new TestResults() {
                    Id = 1,
                    Name = "Student1",
                    Test = "Test1",
                    Date = new DateTime(2020, 1, 1),
                    Mark = 5
                },
                new TestResults() {
                    Id = 2,
                    Name = "Student2",
                    Test = "Test1",
                    Date = new DateTime(2020, 1, 1),
                    Mark = 5
                },
                new TestResults() {
                    Id = 3,
                    Name = "Student3",
                    Test = "Test2",
                    Date = new DateTime(2020, 1, 1),
                    Mark = 5
                }
               };

        [TestMethod]
        public void TestResultsByCourse_WithoutParams_AllObjects()
        {
            var mock = new Mock<IRepository<TestResults>>();
            mock.Setup(e => e.GetAll()).Returns(collection);
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            var res = controller.TestResultsByCourse();
            IEnumerable<TestResults> model = res.Model as IEnumerable<TestResults>;

            Assert.AreEqual(collection.Count, model.Count());
        }

        [TestMethod]
        public void TestResultsByCourse_Test1_2Objects()
        {
            var mock = new Mock<IRepository<TestResults>>();
            mock.Setup(e => e.GetAll()).Returns(collection);
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            var res = controller.TestResultsByCourse("Test1");
            IEnumerable<TestResults> model = res.Model as IEnumerable<TestResults>;

            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void Edit_Id1_Student1()
        {
            var stud1 = new TestResults()
            {
                Id = 1,
                Name = "Student1",
                Test = "Test1",
                Date = new DateTime(2020, 1, 1),
                Mark = 5
            };

            var mock = new Mock<IRepository<TestResults>>();
            mock.Setup(e => e.GetAll()).Returns(collection);
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            var res = controller.Edit(1);
            TestResult model = res.Model as TestResult;

            Assert.AreEqual(stud1, model);
        }
    }
}
