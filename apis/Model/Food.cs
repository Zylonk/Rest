using System;
using System.Collections.Generic;

namespace apis.Model;

public partial class Food
{
    public string FoodId { get; set; } = null!;

    public string FoodName { get; set; } = null!;

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
