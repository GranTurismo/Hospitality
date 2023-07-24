using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class Review
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CompanyId { get; set; }

    public string ReviewMessage { get; set; } = null!;

    public int Rating { get; set; }

    public bool IsAnonymous { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<ReviewImage> ReviewImages { get; set; } = new List<ReviewImage>();

    public virtual User User { get; set; } = null!;
}
