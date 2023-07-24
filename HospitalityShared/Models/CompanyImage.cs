using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class CompanyImage
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
