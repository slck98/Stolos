import { createBrowserRouter, RouterProvider } from "react-router-dom";

import DriverPage from "./pages/Driver";
import GascardPage from "./pages/Gascard";
import RootLayout from "./pages/Root";
import StartScreen from "./pages/Start";
import VehiclePage from "./pages/Vehicle";

// Router
const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    children: [
      {
        index: true,
        element: <StartScreen />,
      },
      { path: "vehicles", element: <VehiclePage /> },
      { path: "drivers", element: <DriverPage /> },
      { path: "gascards", element: <GascardPage /> },
    ],
  },
]);
const App = (props) => {
  return <RouterProvider router={router} />;
};

export default App;
