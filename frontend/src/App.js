import { createBrowserRouter, RouterProvider } from 'react-router-dom';

import ErrorPage from './pages/Error';
import DriverPage from './pages/Driver';
import GascardPage from './pages/Gascard';
import RootLayout from './pages/Root';
import StartScreen from './pages/Start';
import VehiclesRootLayout from './pages/VehiclesRoot';
import VehiclesPage, { loader as vehiclesLoader } from './pages/Vehicles';
import VehicleDetailPage, {
  loader as vehicleDetailLoader,
  action as deleteVehicleAction,
} from './pages/VehicleDetail';
import EditVehiclePage from './pages/EditVehicle';

// Router
const router = createBrowserRouter([
  {
    path: '/',
    element: <RootLayout />,
    errorElement: <ErrorPage />,
    children: [
      {
        index: true,
        element: <StartScreen />,
      },
      {
        path: 'vehicles',
        element: <VehiclesRootLayout />,
        children: [
          {
            index: true,
            element: <VehiclesPage />,
            loader: vehiclesLoader,
          },
          {
            path: ':vinNumber',
            id: 'vehicle-detail',
            loader: vehicleDetailLoader,
            children: [
              {
                index: true,
                element: <VehicleDetailPage />,
                action: deleteVehicleAction,
              },
              {
                path: 'edit',
                element: <EditVehiclePage />,
              },
            ],
          },
        ],
      },
      { path: 'drivers', element: <DriverPage /> },
      { path: 'gascards', element: <GascardPage /> },
    ],
  },
]);
const App = props => {
  return <RouterProvider router={router} />;
};

export default App;
