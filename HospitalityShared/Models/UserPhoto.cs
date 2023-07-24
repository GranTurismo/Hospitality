using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class UserPhoto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
