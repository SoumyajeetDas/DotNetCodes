using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models
{
    public class QuestionPaper
    {
        [Key]
        public int Id { set; get; }

        public int? Time { set; get; }
        public string Question { set; get; }
        public string FirstOption { set; get; }
        public string SecondOption { set; get; }
        public string ThirdOption { set; get; }
        public string FourthOption { set; get; }
        public string CorrectResult { set; get; }
    }
}
