using apis.Model;

namespace apis.ModelDTO
{
    public class RestInfoDTO
    {
        public string RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public string RestaurantAdress { get; set; }

        public string? RestaurantDiscription { get; set; }

        public string RestaurantFood { get; set; }

        public int? RestaurantTableCount { get; set; }

        public static List<RestInfoDTO> ConvertToDTO(List<Restaurant> restaurant)
        {
            List<RestInfoDTO> dto = new List<RestInfoDTO>();
            foreach (var i in restaurant)
            {
                RestInfoDTO items = new RestInfoDTO
                {
                    RestaurantId = i.RestaurantId,
                    RestaurantName = i.RestaurantName,
                    RestaurantAdress = i.RestaurantAdress,
                    RestaurantDiscription = i?.RestaurantDiscription,
                    RestaurantFood = i.RestaurantFood,
                    RestaurantTableCount = i.RestaurantTableCount
                };
                dto.Add(items);
            }
            return dto;
        }
    }
}