using System;
using System.Collections.Generic;

namespace HospitalRoster.API.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string Name { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();
}
