using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ErasmusSDS.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }
    }
}