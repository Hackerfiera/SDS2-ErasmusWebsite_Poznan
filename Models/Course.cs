using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErasmusSDS.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]

        public string Information { get; set; }

        public int DegreeID { get; set; }
    }
}