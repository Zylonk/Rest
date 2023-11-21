export interface IRestaraunt {
  restaurantId: string;
  restaurantAdminId: string;
  restaurantName: string;
  restaurantAdress: string;
  restaurantFood: string;
  restaurantDiscription: string;
  restaurantTablesStatus: string;
  restaurantTableCount: number;
  bookings: Booking[];
}

export type RestarauntsResponse = {
  data: IRestaraunt[];
  count: number;
};

export interface Booking {
  bookingId: string;
  bookingRestaurant: string;
  bookingGuestInfo: string;
  bookingWish: string;
  bookingVisitsofdata: string;
  bookingRestaurantNavigation: string;
}

export interface GuestInfo {
  guestId: string;
  guestName: string;
  guestPhone: string;
  guestSerName: string;
}
