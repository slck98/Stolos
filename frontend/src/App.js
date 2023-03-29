import { createBrowserRouter, RouterProvider } from "react-router-dom";

import ErrorPage from "./pages/Error";
import DriversPage, { loader as driversLoader } from "./pages/Drivers";
import DriverDetailPage, {
  loader as driverDetailLoader,
  action as deleteDriverAction,
} from "./pages/DriverDetail";
import EditDriverPage from "./pages/EditDriver";
import GascardPage from "./pages/Gascards";
import RootLayout from "./pages/Root";
import StartScreen from "./pages/Start";
import VehiclesRootLayout from "./pages/VehiclesRoot";
import DriversRootLayout from "./pages/DriversRoot";
import VehiclesPage, { loader as vehiclesLoader } from "./pages/Vehicles";
import VehicleDetailPage, {
  loader as vehicleDetailLoader,
  action as deleteVehicleAction,
} from "./pages/VehicleDetail";
import EditVehiclePage from "./pages/EditVehicle";

// Router
const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    errorElement: <ErrorPage />,
    children: [
      {
        index: true,
        element: <StartScreen />,
      },
      {
        path: "vehicles",
        element: <VehiclesRootLayout />,
        children: [
          {
            index: true,
            element: <VehiclesPage />,
            loader: vehiclesLoader,
          },
          {
            path: ":vinNumber",
            id: "vehicle-detail",
            loader: vehicleDetailLoader,
            children: [
              {
                index: true,
                element: <VehicleDetailPage />,
                action: deleteVehicleAction,
              },
              {
                path: "edit",
                element: <EditVehiclePage />,
              },
            ],
          },
        ],
      },
      {
        path: "drivers",
        element: <DriversRootLayout />,
        children: [
          {
            index: true,
            element: <DriversPage />,
            loader: driversLoader,
          },
          {
            path: ":natRegNum",
            id: "driver-detail",
            loader: driverDetailLoader,
            children: [
              {
                index: true,
                element: <DriverDetailPage />,
                action: deleteDriverAction,
              },
              {
                path: "edit",
                element: <EditDriverPage />,
              },
            ],
          },
        ],
      },
      { path: "gascards", element: <GascardPage /> },
    ],
  },
]);
const App = (props) => {
  return <RouterProvider router={router} />;
};

export default App;
