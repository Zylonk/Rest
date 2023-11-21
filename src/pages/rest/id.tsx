import { useEffect, useState, useCallback } from "react";
import { useParams } from "react-router-dom";
import { BookingModal, MainLayout } from "@/components";
import { Booking, IRestaraunt } from "@/models";
import { Constants } from "@/types";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import {
  Snackbar,
  CircularProgress,
  Breadcrumbs,
  Link,
  Typography,
  Button,
} from "@mui/material";

import VisotaImage from "@/assets/visota.jpg";

import cl from "./style.module.scss";
import dayjs, { Dayjs } from "dayjs";

export const RestDetails = () => {
  const { id } = useParams();
  const [errorBooking, setErrorBooking] = useState("");
  const [loading, setLoading] = useState(true);
  const [modalOpen, setModalOpen] = useState(false);
  const [data, setData] = useState<IRestaraunt | null>(null);
  const [bookings, setBookings] = useState<Booking[]>([]);
  const [success, setSuccess] = useState(false);

  const [date, setDate] = useState<typeof Dayjs | null>(null);

  useEffect(() => {
    async function getData() {
      try {
        setLoading(true);

        const response = (await fetch(
          `${Constants.BASE_URL}/user/listrest/${id}`
        ).then((res) => res.json())) as IRestaraunt;

        const bookings = (await fetch(
          `${Constants.BASE_URL}/booking/${response.restaurantId}`
        ).then((res) => res.json())) as { data: Booking[] };

        setBookings(bookings.data);
        setData(response);
      } catch (e) {
        console.log(e);
      } finally {
        setLoading(false);
      }
    }

    getData();
  }, [id]);

  const getBookings = async () => {
    if (!data) return;

    const bookings = (await fetch(
      `${Constants.BASE_URL}/booking/${data.restaurantId}`
    ).then((res) => res.json())) as { data: Booking[] };

    setBookings(bookings.data);
  };

  const createBooking = async (guestId: string) => {
    if (!data) return;

    fetch(`${Constants.BASE_URL}/user/listrest/Tabels/booking?`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        id: "123",
        bookingRestaurant: data.restaurantId,
        bookingGuestInfo: guestId,
        bookingWish: "123",
        bookingVisitsofdata: new Date(date?.toString() as string).toJSON(),
      }),
    }).then((res) => res.json());
  };

  const isNewBookingValid = () => {
    const newBooking = new Date(date?.toString() as string);

    console.log(newBooking);

    return (
      newBooking > new Date() &&
      bookings.every((b) => {
        const bookingDate = new Date(b.bookingVisitsofdata);

        if (
          bookingDate.getFullYear() === newBooking.getFullYear() &&
          bookingDate.getDate() === newBooking.getDate()
        ) {
          return false;
        }

        return true;
      })
    );
  };

  const createNewBooking = async (guestId: string) => {
    if (!isNewBookingValid()) {
      setErrorBooking("На представленную дату столики уже забронированы");
    }

    createBooking(guestId);

    getBookings();
  };

  const onOpen = () => setModalOpen(true);
  const onClose = () => setModalOpen(false);

  return (
    <MainLayout>
      {loading && <CircularProgress />}

      <div className="container" style={{ marginTop: 25 }}>
        <Breadcrumbs aria-label="breadcrumb" className={cl.breadcrumb}>
          <Link underline="hover" href="/">
            Главная
          </Link>
          <Typography color="text.primary">{data?.restaurantName}</Typography>
        </Breadcrumbs>
      </div>

      <Snackbar
        open={!loading && !data}
        message="Что то пошло не так"
        autoHideDuration={5000}
      />
      <Snackbar
        open={!!errorBooking}
        message={errorBooking}
        autoHideDuration={5000}
      />
      <Snackbar
        open={success}
        autoHideDuration={5000}
        message="Бронь успешно создана"
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
      />

      <div className="container">
        <Typography variant="h1" className={cl.title}>
          {data?.restaurantName}
        </Typography>

        <div className={cl.contentContainer}>
          <Typography className={cl.description}>
            {data?.restaurantDiscription}
          </Typography>
          <div className={cl.imageContainer}>
            <img src={VisotaImage} alt="" />
          </div>
        </div>
      </div>
      <div className="container">
        <section>
          <Typography variant="h3">Свободные столики</Typography>

          <Typography className={cl.bookText}>
            Забронируйте столик на нужную вам дату
          </Typography>
        </section>
      </div>

      <div className="container">
        <div className={cl.bookInner}>
          <DatePicker
            label="Время и дата"
            format="DD.MM.YYYY"
            value={date}
            onChange={setDate}
            disablePast
          />

          <Button variant="contained" onClick={onOpen}>
            Забронировать
          </Button>
        </div>
      </div>

      <BookingModal
        open={modalOpen}
        onClose={onClose}
        createNewBooking={createNewBooking}
        setSuccess={setSuccess}
        validateBookings={isNewBookingValid}
      />
    </MainLayout>
  );
};
