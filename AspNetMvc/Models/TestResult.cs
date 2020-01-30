using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMvc.Models
{
    public class TestResult : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Display(Name = "Test")]
        public string Test { get; set; }

        [Display(Name = "Completion Date")]
        public string Date { get; set; }

        [Display(Name = "Mark")]
        public int Mark { get; set; }
    }
}