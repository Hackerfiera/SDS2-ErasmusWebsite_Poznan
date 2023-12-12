using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ErasmusSDS.Models
{
    public class LA
    {
        [Key]
        public int LAID { get; set; }

        public String NombreEstudiante { get; set; }

        public String status { get; set; }

        public List<string> Courses { get; set; } = new List<string>();
    }
}