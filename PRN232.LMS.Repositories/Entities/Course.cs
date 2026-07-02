using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRN232.LMS.Models.Entities;

public partial class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Courseid { get; set; }

    public string Coursename { get; set; } = null!;

    public int Semesterid { get; set; }
    public string Coursecode { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Semester Semester { get; set; } = null!;
}
