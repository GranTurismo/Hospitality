using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class ReviewImage
{
    public int Id { get; set; }

    public int ReviewId { get; set; }

    public virtual Review Review { get; set; } = null!;
}
