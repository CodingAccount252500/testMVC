using System;
using System.Collections.Generic;

namespace testMVC.Models
{
    public partial class User
    {
        public User()
        {
            UserCourses = new HashSet<UserCourse>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Key { get; set; }
        public string? Iv { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
