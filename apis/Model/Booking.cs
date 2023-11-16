using System;
using System.Collections.Generic;

namespace apis.Model;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public string BookingRestaurant { get; set; } = null!;

    public string BookingGuestInfo { get; set; } = null!;

    public string? BookingWish { get; set; }

    public DateTime BookingVisitsofdata { get; set; }

    public virtual GuestInfo BookingGuestInfoNavigation { get; set; } = null!;

    public virtual Restaurant BookingRestaurantNavigation { get; set; } = null!;
}
