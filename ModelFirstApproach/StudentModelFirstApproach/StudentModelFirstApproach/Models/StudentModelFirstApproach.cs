using System;
using System.Collections.Generic;

namespace StudentModelFirstApp.Models;

public partial class StudentModelFirstApproach
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string RollNumber { get; set; } = null!;

    public string? Country { get; set; }
}
