using System;
using System.Collections.Generic;

namespace testMVC.Models
{
    public partial class UserCourse
    {
        public int UserCourseId { get; set; }
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? Note { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? User { get; set; }
    }
}
