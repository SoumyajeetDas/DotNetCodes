using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models
{
    public class UploadFile
    {
        [Required(ErrorMessage ="Enter the Time")]
        public int? Time { set; get; }

        [Required(ErrorMessage ="Upload the Question Paper")]
        [DataType(DataType.Upload)]
        public IFormFile QsFile { set; get; }

        [Required(ErrorMessage ="Upload the Student List")]
        [DataType(DataType.Upload)]
        public IFormFile StuFile { set; get; }

    }
}
