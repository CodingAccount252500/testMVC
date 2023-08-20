using System.Diagnostics.Metrics;
using testMVC.Models;

namespace testMVC.DTO.Res
{
    public class GetAllCourses
    {
        public int Pagesize { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public List<Course> Courses { get; set; }
    }
}
