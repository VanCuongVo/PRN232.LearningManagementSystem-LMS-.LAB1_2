using System;
using System.Collections.Generic;

namespace PRN232.LMS.Repositories.Entities;

public partial class Student
{
    public int Studentid { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Dateofbirth { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public string Studentcode { get; set; } = null!;
    public int Age { get; set; }
    public string Phonenumber { get; set; } = null!;

    // Navigation
    public ICollection<User> Users { get; set; }
        = new List<User>();
}
