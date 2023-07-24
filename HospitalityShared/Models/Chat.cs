using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class Chat
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CompanyId { get; set; }

    public bool IsChatFinished { get; set; }

    public DateTime StartDate { get; set; }

    public virtual ICollection<ChatImage> ChatImages { get; set; } = new List<ChatImage>();

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual Company Company { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
