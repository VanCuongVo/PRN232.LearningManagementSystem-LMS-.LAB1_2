using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PRN232.LMS.Models.Enum;

namespace PRN232.LMS.Models.Entities;

public partial class Enrollment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Enrollmentid { get; set; }

    public int Studentid { get; set; }

    public int Courseid { get; set; }

    public DateTime Enrolldate { get; set; }

    public EnrollmentStatus Status { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
