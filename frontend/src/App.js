import { createBrowserRouter, RouterProvider } from 'react-router-dom';

import DriverPage from './pages/Driver';
import GascardPage from './pages/Gascard';
import RootLayout from './pages/Root';
import StartScreen from './pages/Start';
import VehiclePage, { loadVehicles } from './pages/Vehicle';
import VehicleDetailPage from './pages/VehicleDetail';
import EditVehiclePage from './pages/EditVehicle';

// Router
const router = createBrowserRouter([
  {
    path: '/',
    element: <RootLayout />,
    children: [
      {
        index: true,
        element: <StartScreen />,
      },
      {
        path: 'vehicles',
        element: <VehiclePage />,
        loader: loadVehicles,
        children: [
          {
            path: ':vehicleId',
            children: [
              {
                index: true,
                element: <VehicleDetailPage />,
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
