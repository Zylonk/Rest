using Microsoft.AspNetCore.Mvc;
using apis.Model;
using apis.ModelDTO;
using apis.DataBase;
using apis.Class;
using Newtonsoft.Json;

namespace apis.Controllers
{
    [ApiController]
    public class AdminRegistrationandAuth : ControllerBase
    {
        private static JsonSerializerSettings jsonSerializerSettingss = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        [HttpPost]
        [Route("/admin/registration")]
        public async Task<OkResult> AdminRegistrations([FromBody] AdminRegistrationDTO adminRegistrationDTO)
        {
            adminRegistrationDTO.ID = Guid.NewGuid().ToString();
            GetrContext.Context.Adminrestaurants.Add(AdminRegistrationDTO.AdminConverter(adminRegistrationDTO));
            GetrContext.Context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("/admin/log")]
        public ActionResult<Adminrestaurant> AdminAuths([FromBody] AdminAuth adminAuth)
        {
            var pasword = adminAuth.AdminPassword;
            AdminRegistrationDTO getDTO = new AdminRegistrationDTO();
            Adminrestaurant admin = GetrContext.Context.Adminrestaurants.ToList().FirstOrDefault(x => x.AdminLogin == adminAuth.AdminLogin && x.AdminPassword == pasword);
            if (admin != null)
            {
                GlobalID id = new GlobalID();
                id.AdminID = admin.AdminId;
                getDTO = AdminRegistrationDTO.AdminConverterDTO(admin);
                return Content(JsonConvert.SerializeObject(getDTO,jsonSerializerSettingss));
            }
            return BadRequest();
        }
    }
}
