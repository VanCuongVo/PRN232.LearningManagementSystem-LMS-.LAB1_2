using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRN232.LMS.Models.Entities;

public partial class Subject
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Subjectid { get; set; }

    public string Subjectcode { get; set; } = null!;

    public string Subjectname { get; set; } = null!;

    public int Credit { get; set; }
}
