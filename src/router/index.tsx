import { MainPage, RestDetails } from "@/pages";
import { createBrowserRouter } from "react-router-dom";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <MainPage />,
  },
  {
    path: "/rest/:id",
    element: <RestDetails />,
  },
]);
