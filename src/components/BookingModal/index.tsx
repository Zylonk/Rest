import { Dispatch, FC, SetStateAction } from "react";

import { Constants } from "@/types";
import { GuestInfo } from "@/models";

import { Button, Modal, TextField, Typography } from "@mui/material";
import { useCallback } from "react";
import { useForm } from "react-hook-form";

import { toast } from "react-toastify";

import cl from "./style.module.scss";

type BookingFormValues = {
  guestSerName: string;
  guestName: string;
  guestPhone: string;
};

type BookingModalProps = {
  open: boolean;
  onClose: () => void;
  createNewBooking: (guestId: string) => void;
  setSuccess: Dispatch<SetStateAction<boolean>>;
  validateBookings: () => boolean;
};

export const BookingModal: FC<BookingModalProps> = ({
  onClose,
  open,
  createNewBooking,
  setSuccess,
  validateBookings,
}) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<BookingFormValues>();

  const onSubmit = useCallback(
    handleSubmit(async (body) => {
      if (!validateBookings()) {
        toast.error(
          "На указанную дату уже существует бронь. Выберите другую дату",
          {
            position: "top-right",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: false,
            pauseOnHover: true,
            theme: "light",
          }
        );
        return;
      }

      const guest = (await fetch(`${Constants.BASE_URL}/guest`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ ...body, guestId: "" }),
      }).then((res) => res.json())) as GuestInfo;

      createNewBooking(guest.guestId);
      setSuccess(true);
      onClose();
    }),
    [setSuccess, createNewBooking, validateBookings]
  );

  return (
    <Modal open={open} onClose={onClose} className={cl.modal}>
      <div className={cl.modalContainer}>
        <Typography variant="h4">Заполните форму</Typography>

        <form onSubmit={onSubmit} className={cl.form}>
          <TextField
            {...register("guestName", { required: true })}
            id="name"
            variant="outlined"
            label="Ваше имя"
            error={!!errors.guestName?.message}
            required
          />
          <TextField
            {...register("guestSerName")}
            type="phone"
            variant="outlined"
            label="Ваша фамилия"
          />
          <TextField
            {...register("guestPhone")}
            variant="outlined"
            label="Ваш телефон"
          />

          <Button variant="contained" type="submit">
            Подтвердить
          </Button>
        </form>
      </div>
    </Modal>
  );
};
