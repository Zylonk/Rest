using Microsoft.AspNetCore.Mvc;
using apis.ModelDTO;
using apis.DataBase;
using apis.Class;
using apis.Model;
using Newtonsoft.Json;

namespace apis.Controllers
{   

    [ApiController]

    public class AdminFunction : ControllerBase
    {
        private static JsonSerializerSettings jsonSerializerSettingss = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        [HttpPost]
        [Route("/admin/restaurant/add")]
        public ActionResult<Restaurant> AddRestaurant([FromBody] RestaurantDTO restaurantDTO, string adminID)
        {
            TablesInRestaurant table = new TablesInRestaurant();
            table.TableId = restaurantDTO.RestaurantTablesStatus.ToString();
            restaurantDTO.RestaurantId = Guid.NewGuid().ToString();
            table.TableRestaurant = restaurantDTO.RestaurantId.ToString();
            
            restaurantDTO.RestaurantAdminId = adminID;
            GetrContext.Context.Restaurants.Add(RestaurantDTO.ConvertRestaurant(restaurantDTO));
            GetrContext.Context.TablesInRestaurants.Add(table);
            GetrContext.Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("/admin/restaurant/remove")]
        public ActionResult<Restaurant> RemoveRestaurant(string restID) {
            List<Restaurant> rest = GetrContext.Context.Restaurants.ToList().Where(x => x.RestaurantId == restID).ToList();
            List<Booking> booking = GetrContext.Context.Bookings.ToList().Where(x => x.BookingRestaurant == restID).ToList();
            if (rest != null)
            {
                GetrContext.Context.Bookings.RemoveRange(booking);
                GetrContext.Context.Restaurants.RemoveRange(rest);
                GetrContext.Context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }
    }
}
