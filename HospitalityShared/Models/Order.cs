using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CompanyId { get; set; }

    public bool IsAcceptedByClinic { get; set; }

    public double PaidAmount { get; set; }

    public bool IsConfirmedVisitByUser { get; set; }

    public int ProcedureId { get; set; }

    public bool IsProcedureFinished { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Procedure Procedure { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
