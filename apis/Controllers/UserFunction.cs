using apis.DataBase;
using apis.Model;
using apis.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace apis.Controllers
{
    [ApiController]
    public class UserFunction : ControllerBase
    {
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        [Route("/user/listrest")]
        [HttpGet]
        public ActionResult<List<Restaurant>> RestaurantList(int page,int limit)
        {
            RestInfoDTO restInf = new RestInfoDTO();
            
            var count = GetrContext.Context.Restaurants.Count();
            var rest = GetrContext.Context.Restaurants.Skip(page * limit - limit).ToList();
            List<RestInfoDTO> restdto = RestInfoDTO.ConvertToDTO(rest);
            if (rest != null)
            {
                return Content(JsonConvert.SerializeObject(restdto, serializerSettings));
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("/user/listrest/Tabels/booking")]
        public ActionResult<Booking> BookingAdd([FromBody] BookingDTO bookingDTO, string rest, string guest  ) {
           
            bookingDTO.Id = Guid.NewGuid().ToString();
            bookingDTO.BookingRestaurant =  guest;
            bookingDTO.BookingGuestInfo = rest;
            GetrContext.Context.Bookings.Add(BookingDTO.BookConvertDTO(bookingDTO));
            GetrContext.Context.SaveChanges();
            return Ok();
        }
    }
}
