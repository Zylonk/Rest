using System;
using System.Collections.Generic;

namespace apis.Model;

public partial class GuestInfo
{
    public string GuestId { get; set; } = null!;

    public string GuestSerName { get; set; } = null!;

    public string GuestName { get; set; } = null!;

    public string GuestPhone { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
