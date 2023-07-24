using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class Procedure
{
    public int Id { get; set; }

    public string NameKa { get; set; } = null!;

    public double Price { get; set; }

    public int CompanyId { get; set; }

    public string NameTr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string NameRu { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
