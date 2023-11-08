using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ErasmusSDS.Models
{
    public class Degree
    {
        [Key]
        public int DegreeID { get; set; }
        public string Name { get; set; }
    }
}