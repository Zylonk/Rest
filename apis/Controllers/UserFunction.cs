using apis.DataBase;
using apis.Model;
using apis.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace apis.Controllers
{
    [ApiController]
    public class UserFunction : ControllerBase
    {
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings() 
        { 
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        [Route("/user/listrest")]
        [HttpGet]
        public ActionResult<List<Restaurant>> RestaurantList(int page,int limit)
        {
            var rest = GetrContext.Context.Restaurants.Skip(page * limit - limit).ToList();
            var count = GetrContext.Context.Restaurants.Count();
            List<RestInfoDTO> restdto = RestInfoDTO.ConvertToDTO(rest);

            if (rest != null)
            {
                return Ok(JsonConvert.SerializeObject(new { count , data = restdto }, serializerSettings));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("/user/listrest/{id}")]
        public ActionResult<Restaurant> GetRestarauntById(string id)
        {
            var candidate = GetrContext.Context.Restaurants.FirstOrDefault(r => r.RestaurantId == id);

            if (candidate == null)
            {
                return BadRequest();
            }

            return Ok(RestInfoDTO.ConvertToDto(candidate));
        }
        
        [HttpPost]
        [Route("/user/listrest/Tabels/booking")]
        public ActionResult<Booking> BookingAdd([FromBody] BookingDTO bookingDTO, string rest, string guest) {
           
            bookingDTO.Id = Guid.NewGuid().ToString();
            bookingDTO.BookingRestaurant =  guest;
            bookingDTO.BookingGuestInfo = rest;
            GetrContext.Context.Bookings.Add(BookingDTO.BookConvertDTO(bookingDTO));
            GetrContext.Context.SaveChanges();
            return Ok();
        }
    }
}
