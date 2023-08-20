using System;
using System.Collections.Generic;

namespace testMVC.Models
{
    public partial class Course
    {
        public Course()
        {
            UserCourses = new HashSet<UserCourse>();
        }

        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        public string? InstructorName { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
