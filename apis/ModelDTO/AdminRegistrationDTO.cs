using apis.Controllers;
using apis.Model;

namespace apis.ModelDTO
{
    public class AdminRegistrationDTO
    {
        public string ID { get; set; }
        public string AdminLogin { get; set; }
        public string AdminPassword { get; set; }
        public string AdminPhone { get; set; }
        public static Adminrestaurant AdminConverter(AdminRegistrationDTO adminRegistrationDTO) {
            Adminrestaurant admin  = new Adminrestaurant();
            admin.AdminId = adminRegistrationDTO.ID;
            admin.AdminLogin = adminRegistrationDTO.AdminLogin;
            admin.AdminPassword = adminRegistrationDTO.AdminPassword;
            admin.AdminPhone = adminRegistrationDTO.AdminPhone;
            return admin;
        }
        public static AdminRegistrationDTO AdminConverterDTO(Adminrestaurant adminRegistrationDTO)
        {
            AdminRegistrationDTO admin = new AdminRegistrationDTO();
            admin.ID = adminRegistrationDTO.AdminId;
            admin.AdminLogin = adminRegistrationDTO.AdminLogin;
            admin.AdminPassword = adminRegistrationDTO.AdminPassword;
            admin.AdminPhone = adminRegistrationDTO.AdminPhone;
            return admin;
        }
      
    }
}

