using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int BirthDay { get; set; }

    public int BirthMonth { get; set; }

    public int? BirthYear { get; set; }

    public string PersonalId { get; set; } = null!;

    public string? Mail { get; set; }

    public DateTime RegisterDate { get; set; }

    public int Sex { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<UserPhoto> UserPhotos { get; set; } = new List<UserPhoto>();
}
