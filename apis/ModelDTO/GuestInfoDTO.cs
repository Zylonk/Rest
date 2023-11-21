using apis.Model;

namespace apis.ModelDTO
{
    public class GuestInfoDTO
    {
        public string GuestId { get; set; } = null!;

        public string GuestSerName { get; set; } = null!;

        public string GuestName { get; set; } = null!;

        public string GuestPhone { get; set; } = null!;

        public static GuestInfoDTO ConvertToDTO(GuestInfo guest)
        {
            var dto = new GuestInfoDTO()
            {
                GuestId = guest.GuestId,
                GuestName = guest.GuestName,
                GuestPhone = guest.GuestPhone,
                GuestSerName = guest.GuestSerName
            };

            return dto;
        }
    }
}
