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
                    Name = "Student1",
                    Test = "Test1",
                    Date = "2020-01-01",
                    Mark = 5
                },
                new TestResults() {
                    Name = "Student2",
                    Test = "Test1",
                    Date = "2020-01-01",
                    Mark = 5
                },
                new TestResults() {
                    Name = "Student3",
                    Test = "Test2",
                    Date = "2020-01-01",
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
    }
}
