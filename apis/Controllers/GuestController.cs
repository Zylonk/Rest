using apis.DataBase;
using apis.Model;
using apis.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace apis.Controllers
{
    [Route("/guest")]
    [ApiController]
    public class GuestController : Controller
    {
        [HttpPost]
        [Route("")]
        public ActionResult<GuestInfoDTO> CreateGuest([FromBody] GuestInfoDTO guestDto)
        {
            guestDto.GuestId = Guid.NewGuid().ToString();

            GetrContext.Context.GuestInfos.Add(
                new GuestInfo() 
                {
                    GuestId = guestDto.GuestId, 
                    GuestName = guestDto.GuestName, 
                    GuestPhone = guestDto.GuestPhone, 
                    GuestSerName = guestDto.GuestSerName 
                }
            );

            GetrContext.Context.SaveChanges();

            return guestDto;
        }
    }
}
