import { LocalizationProvider } from "@mui/x-date-pickers";
import { RouterProvider } from "react-router-dom";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { router } from "@/router";
import { ToastContainer } from "react-toastify";

import "./App.css";
import "react-toastify/dist/ReactToastify.css";

function App() {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <RouterProvider router={router} />
      <ToastContainer />
    </LocalizationProvider>
  );
}

export default App;
