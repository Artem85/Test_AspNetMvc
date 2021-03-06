﻿using AspNetMvc.Infrastructure;
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
        private const string allTestsValue = "All";
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

        public ViewResult TestResultsByCourse(string test = allTestsValue)
        {
            IEnumerable<TestResult> model = Repository.GetAll().OrderBy(e => e.Test);

            if (test != allTestsValue)
            {
                model = model.Where(e => e.Test == test);
            }

            ViewBag.SelectedCourse = test;
            return View(model);
        }

        public PartialViewResult TestResultsByCourseMenu(string test = allTestsValue)
        {
            ViewBag.SelectedCourse = test;
            List<string> courses = new List<string>();

            courses.Add(allTestsValue);
            courses.AddRange(Repository.GetAll()
                    .Select(e => e.Test)
                    .Distinct().OrderBy(e => e));

            return PartialView(courses);
        }

        public ActionResult TestResultSelection()
        {
            ViewBag.selTestName = CreateTestNameList();
            return View(Repository.GetAll());
        }

        List<SelectListItem> CreateTestNameList(string selectedValue = "", string skippedValue = "")
        {
            List<string> values = new List<string>();
            values.Add(allTestsValue);
            values.AddRange(Repository.GetAll()
                .Select(e => e.Test).Distinct());

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in values)
            {
                if (e == skippedValue)
                    continue;
                list.Add(new SelectListItem
                {
                    Text = e,
                    Value = e,
                    Selected = e == selectedValue
                });
            }
            return list;
        }

        public PartialViewResult _SelectData(
                                            string selName,
                                            string selTestName,
                                            DateTime? startDate,
                                            DateTime? endDate,
                                            int? selMark
                                            )
        {
            var model = Repository.GetAll();

            if (!string.IsNullOrWhiteSpace(selName))
                model = model.Where(e => e.Name.ToLower()
                    .Contains(selName.ToLower()));
            if (!string.IsNullOrWhiteSpace(selTestName) && selTestName != allTestsValue)
                model = model.Where(e => e.Test.ToLower()
                    .Contains(selTestName.ToLower()));
            if (startDate.HasValue)
                model = model.Where(e => e.Date >= startDate.Value);
            if (endDate.HasValue)
                model = model.Where(e => e.Date <= endDate.Value);
            if (selMark.HasValue)
                model = model.Where(e => e.Mark == selMark);

            System.Threading.Thread.Sleep(1500);
            return PartialView("_TableBody", model);
        }

        public ActionResult Edit(int id)
        {
            TestResult entityObject = Repository.GetById(id);
            ViewBag.Test = CreateTestNameList(entityObject.Test, allTestsValue);
            return View(entityObject);
        }

        [HttpPost]
        public ActionResult Edit(TestResult model) {
            if (ModelState.IsValid)
            {
                Repository.Update(model);
                return RedirectToAction("TestResultsList");
            }
            ViewBag.Test = CreateTestNameList(model.Test, allTestsValue);
            return View(model);
        }
    }
}