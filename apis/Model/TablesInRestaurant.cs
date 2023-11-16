using System;
using System.Collections.Generic;

namespace apis.Model;

public partial class TablesInRestaurant
{
    public string TableId { get; set; } = null!;

    public string? TableRestaurant { get; set; }

    public bool? TableStatus { get; set; }

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
