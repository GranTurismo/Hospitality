using System;
using System.Collections.Generic;

namespace HospitalityShared.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CompanyRegistrationId { get; set; } = null!;

    public double ReservationPrice { get; set; }

    public int ClinicProfile { get; set; }

    public string Description { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public int SubscriptionMethod { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ICollection<AdditionalService> AdditionalServices { get; set; } = new List<AdditionalService>();

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<CompanyImage> CompanyImages { get; set; } = new List<CompanyImage>();

    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
