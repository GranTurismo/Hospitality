using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class Config
{
    public int Id { get; set; }

    public int Key { get; set; }

    public string Name { get; set; } = null!;

    public int? IntValue { get; set; }

    public double? DoubleValue { get; set; }

    public string? StringValue { get; set; }
}
