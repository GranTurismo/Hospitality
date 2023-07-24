using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class ChatImage
{
    public int Id { get; set; }

    public int ChatId { get; set; }

    public int MessageId { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual ChatMessage Message { get; set; } = null!;
}
