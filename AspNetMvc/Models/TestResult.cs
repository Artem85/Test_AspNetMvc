using Common.Attributes;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc.Models
{
    public class TestResult : IEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Display(Name = "Test")]
        public string Test { get; set; }

        [Required]
        [CustomDateAttribute]
        [Display(Name = "Completion Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Range (1, 5)]
        [Display(Name = "Mark")]
        public int Mark { get; set; }
    }
}