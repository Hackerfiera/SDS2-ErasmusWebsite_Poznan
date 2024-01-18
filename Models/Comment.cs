using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErasmusSDS.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string AuthorID { get; set; }

        [DataType(DataType.MultilineText)]

        public bool Positive { get; set; }

        public string Text { get; set; }

        public int CourseID { get; set; }
    }
}