using System;
using System.Collections.Generic;

namespace HospitalRoster.API.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
