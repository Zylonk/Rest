using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace apis.Model;

public partial class Restaurant
{
    public string RestaurantId { get; set; } = null!;

    public string RestaurantAdminId { get; set; } = null!;

    public string RestaurantName { get; set; } = null!;

    public string RestaurantAdress { get; set; } = null!;

    public string? RestaurantDiscription { get; set; }

    public string RestaurantFood { get; set; } = null!;

    public string RestaurantTablesStatus { get; set; } = null!;

    public int? RestaurantTableCount { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Adminrestaurant RestaurantAdmin { get; set; } = null!;

    public virtual Food RestaurantFoodNavigation { get; set; } = null!;

    public virtual TablesInRestaurant RestaurantTablesStatusNavigation { get; set; } = null!;
}
