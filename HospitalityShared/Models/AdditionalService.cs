using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class AdditionalService
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string ServiceNameKa { get; set; } = null!;

    public string ServiceNameEn { get; set; } = null!;

    public string ServiceNameTr { get; set; } = null!;

    public string ServiceNameRu { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
