using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ErasmusSDS.Models
{
    public class Degree
    {
        [Key]
        public int DegreeID { get; set; }
        public string Name { get; set; }
    }
}