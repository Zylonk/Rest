using apis.DataBase;
using apis.Model;
using apis.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace apis.Controllers
{
    [Route("/booking")]
    [ApiController]
    public class BookingController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Booking> GetAllBookingsForRest(string id)
        {
            var candidates = GetrContext.Context.Bookings.Where(b => b.BookingRestaurant == id).ToList();

            if (candidates == null)
            {
                return NotFound();
            }

            var dtoArr = new BookingDTO[candidates.Count()];

            for (int i = 0; i < candidates.Count(); i++)
            {
                dtoArr[i] = BookingDTO.ConvertBookingToDTO(candidates.ElementAt(i));
            }

            return Ok(new { data = dtoArr });
        }
    }
}
