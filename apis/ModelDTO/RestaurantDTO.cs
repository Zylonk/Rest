using apis.Model;

namespace apis.ModelDTO
{
    public class RestaurantDTO
    {
        public string RestaurantId { get; set; } 

        public string RestaurantAdminId { get; set; } 

        public string RestaurantName { get; set; } 

        public string RestaurantAdress { get; set; }

        public string? RestaurantDiscription { get; set; }

        public string RestaurantFood { get; set; }

        public string RestaurantTablesStatus { get; set; }

        public int? RestaurantTableCount { get; set; }
        public static Restaurant ConvertRestaurant(RestaurantDTO restaurantDTO){ 
            Restaurant rest = new Restaurant();
            rest.RestaurantId = restaurantDTO.RestaurantId;
            rest.RestaurantAdminId = restaurantDTO.RestaurantId;
            rest.RestaurantName = restaurantDTO.RestaurantName;
            rest.RestaurantAdress = restaurantDTO.RestaurantAdress;
            rest.RestaurantDiscription = restaurantDTO?.RestaurantDiscription;
            rest.RestaurantFood = restaurantDTO.RestaurantFood;
            rest.RestaurantTablesStatus = restaurantDTO.RestaurantFood;
            rest.RestaurantTableCount = restaurantDTO.RestaurantTableCount;
            return rest;
        }
        public static List<RestaurantDTO> ListRestConverterDTO(List<Restaurant> adminRegistrationDTO)
        {
            List<RestaurantDTO> rest = new List<RestaurantDTO>();
            foreach (var i in adminRegistrationDTO)
            {
                rest.Add(new RestaurantDTO{
                    RestaurantId = i.RestaurantId,
                    RestaurantAdminId = i.RestaurantId,
                    RestaurantName = i.RestaurantName,
                    RestaurantAdress = i.RestaurantAdress,
                    RestaurantDiscription = i.RestaurantDiscription,
                    RestaurantFood = i.RestaurantFood,
                    RestaurantTablesStatus = i.RestaurantFood,
                    RestaurantTableCount = i.RestaurantTableCount,

                });
               
            }
            return rest;
        }

    }
}
