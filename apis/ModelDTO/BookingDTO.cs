using apis.Model;

namespace apis.ModelDTO
{
    public class BookingDTO
    {
        public string Id { get; set; } = null!;

        public string BookingRestaurant { get; set; } = null!;

        public string BookingGuestInfo { get; set; } = null!;

        public string? BookingWish { get; set; }

        public DateTime BookingVisitsofdata { get; set; }
        public static  Booking BookConvertDTO(BookingDTO booking) {
            Booking bookingDTO = new Booking();
            bookingDTO.BookingId = booking.Id;
            bookingDTO.BookingRestaurant = booking.BookingRestaurant;
            bookingDTO.BookingGuestInfo = booking.BookingGuestInfo;
            bookingDTO.BookingWish = booking.BookingWish;
            bookingDTO.BookingVisitsofdata = booking.BookingVisitsofdata;
            return bookingDTO;
        }

        public static BookingDTO ConvertBookingToDTO(Booking booking)
        {
            BookingDTO bookingDTO = new BookingDTO();
            bookingDTO.Id = booking.BookingId;
            bookingDTO.BookingRestaurant = booking.BookingRestaurant;
            bookingDTO.BookingGuestInfo = booking.BookingGuestInfo;
            bookingDTO.BookingWish = booking.BookingWish;
            bookingDTO.BookingVisitsofdata = booking.BookingVisitsofdata;

            return bookingDTO;
        }
    }
}
