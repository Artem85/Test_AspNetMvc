using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestResults = AspNetMvc.Models.TestResult;
using System.Collections.Generic;
using Moq;
using Common.Repositories.Interfaces;
using AspNetMvc.Controllers;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc.Tests.Controllers
{
    [TestClass]
    public class TestResultControllerTest
    {
        readonly ICollection<MyTestResults> collection =
               new List<MyTestResults> {
                new MyTestResults() {
                    Id = 1,
                    Name = "Student1",
                    Test = "Test1",
                    Date = new DateTime(2020, 1, 1),
                    Mark = 5
                },
                new MyTestResults() {
                    Id = 2,
                    Name = "Student2",
                    Test = "Test1",
                    Date = new DateTime(2020, 1, 1),
                    Mark = 5
                },
                new MyTestResults() {
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
            var mock = new Mock<IRepository<MyTestResults>>();
            mock.Setup(e => e.GetAll()).Returns(collection);
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            var res = controller.TestResultsByCourse();
            IEnumerable<MyTestResults> model = res.Model as IEnumerable<MyTestResults>;

            Assert.AreEqual(collection.Count, model.Count());
        }

        [TestMethod]
        public void TestResultsByCourse_Test1_2Objects()
        {
            var mock = new Mock<IRepository<MyTestResults>>();
            mock.Setup(e => e.GetAll()).Returns(collection);
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            var res = controller.TestResultsByCourse("Test1");
            IEnumerable<MyTestResults> model = res.Model as IEnumerable<MyTestResults>;

            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void Edit_Id1_Student1()
        {
            var stud1 = collection.First();

            var mock = new Mock<IRepository<MyTestResults>>();
            mock.Setup(e => e.GetAll()).Returns(collection);
            mock.Setup(e => e.GetById(stud1.Id)).Returns(stud1);
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            var res = controller.Edit(stud1.Id);
            MyTestResults model = (res as ViewResult).Model as MyTestResults;

            Assert.AreEqual(stud1, model);
        }

        [TestMethod]
        public void Edit_Repository_UpdateIsCalled()
        {
            var mock = new Mock<IRepository<MyTestResults>>();
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            MyTestResults model = new MyTestResults();
            var res = controller.Edit(model);

            mock.Verify(e => e.Update(model));
        }

        [TestMethod]
        public void Edit_Result_RedirectToTestResultsList()
        {
            var mock = new Mock<IRepository<MyTestResults>>();
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            MyTestResults model = new MyTestResults();
            var res = controller.Edit(model);

            Assert.IsInstanceOfType(res, typeof(RedirectToRouteResult));
            var redirectResult = res as RedirectToRouteResult;
            Assert.AreEqual(redirectResult.RouteValues["action"], "TestResultsList");
        }

        [TestMethod]
        public void Edit_ModelStateIsNotValid_UpdateNeverCalled()
        {
            var mock = new Mock<IRepository<MyTestResults>>();
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            MyTestResults model = new MyTestResults();
            controller.ModelState.AddModelError("", "Error message");

            var res = controller.Edit(model);

            mock.Verify(e => e.Update(model), Times.Never());
        }

        [TestMethod]
        public void Edit_ModelStateIsNotValid_ReturnTestResultModel()
        {
            var mock = new Mock<IRepository<MyTestResults>>();
            var controller = new TestResultController()
            {
                Repository = mock.Object
            };

            MyTestResults model = new MyTestResults();
            controller.ModelState.AddModelError("", "Error message");

            var res = controller.Edit(model);

            Assert.IsInstanceOfType((res as ViewResult).Model, typeof(MyTestResults));
        }
    }
}
