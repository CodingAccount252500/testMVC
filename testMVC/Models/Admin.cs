﻿using System;
using System.Collections.Generic;

namespace testMVC.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
    }
}
