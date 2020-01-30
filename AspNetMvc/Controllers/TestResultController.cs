using AspNetMvc.Infrastructure;
using AspNetMvc.Models;
using Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc.Controllers
{
    public class TestResultController : Controller
    {
        public IRepository<TestResult> Repository { get; set; }

        public TestResultController()
        {
            Repository = DataContext.Repository;
        }
        // GET: TestResult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestResultsList()
        {
            return View(Repository.GetAll());
        }

        public ViewResult TestResultsByCourse(string test = "All")
        {
            IEnumerable<TestResult> model = Repository.GetAll().OrderBy(e => e.Test);

            if (test != "All")
            {
                model = model.Where(e => e.Test == test);
            }

            ViewBag.SelectedCourse = test;
            return View(model);
        }

        public PartialViewResult TestResultsByCourseMenu(string test = "All")
        {
            ViewBag.SelectedCourse = test;
            List<string> courses = new List<string>();

            courses.Add("All");
            courses.AddRange(Repository.GetAll()
                    .Select(e => e.Test)
                    .Distinct().OrderBy(e => e));

            return PartialView(courses);
        }
    }
}