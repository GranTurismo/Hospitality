using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class ChatMessage
{
    public int Id { get; set; }

    public int ChatId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime MessageDate { get; set; }

    public bool IsPhotoAttached { get; set; }

    public bool IsSeen { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual ICollection<ChatImage> ChatImages { get; set; } = new List<ChatImage>();
}
