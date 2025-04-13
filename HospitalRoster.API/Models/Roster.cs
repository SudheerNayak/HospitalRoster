using System;
using System.Collections.Generic;

namespace HospitalRoster.API.Models;

public partial class Roster
{
    public int RosterId { get; set; }

    public int? StaffId { get; set; }

    public int? ShiftId { get; set; }
    public string? StaffName { get; set; }
    public string? DepartmentName { get; set; }
    public string? ShiftName { get; set; }
    

    public DateOnly Date { get; set; }

    public int? DepartmentId { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Shift? Shift { get; set; }

    public virtual Staff? Staff { get; set; }
}
