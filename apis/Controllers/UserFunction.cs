using apis.DataBase;
using apis.Model;
using apis.ModelDTO;
using apis.Services;
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
        FoodService _foodService = new FoodService();

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

            foreach (RestInfoDTO item in restdto)
            {
                item.RestaurantFood = _foodService.GetFoodById(item.RestaurantFood).Result?.FoodName;
            }

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

            var dto = RestInfoDTO.ConvertToDto(candidate);
            dto.RestaurantFood = _foodService.GetFoodById(candidate.RestaurantFood).Result?.FoodName;

            return Ok(dto);
        }
        
        [HttpPost]
        [Route("/user/listrest/Tabels/booking")]
        public ActionResult<Booking> BookingAdd([FromBody] BookingDTO bookingDTO) {
           
            bookingDTO.Id = Guid.NewGuid().ToString();
            GetrContext.Context.Bookings.Add(BookingDTO.BookConvertDTO(bookingDTO));
            GetrContext.Context.SaveChanges();
            return Ok();
        }
    }
}
