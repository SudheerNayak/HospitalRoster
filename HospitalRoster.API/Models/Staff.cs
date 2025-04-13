using System;
using System.Collections.Generic;

namespace HospitalRoster.API.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public int? DepartmentId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}
