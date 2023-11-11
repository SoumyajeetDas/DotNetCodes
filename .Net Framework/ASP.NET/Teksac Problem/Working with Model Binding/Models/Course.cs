using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Working_with_Model_Binding.Models
{
    public class Course
    {
        public String CourseName { get; set; }
        public String CourseId { get; set; }
        public int Duration { get; set; }
        public string Level { get; set; }
    }

    public class Department
    {
        public List<String> CourseList { get; set; }
    }
}