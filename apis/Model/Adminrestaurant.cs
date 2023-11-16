using System;
using System.Collections.Generic;

namespace apis.Model;

public partial class Adminrestaurant
{
    public string AdminId { get; set; } = null!;

    public string AdminLogin { get; set; } = null!;

    public string AdminPassword { get; set; } = null!;

    public string AdminPhone { get; set; } = null!;

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
