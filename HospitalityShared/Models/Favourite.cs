using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class Favourite
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
