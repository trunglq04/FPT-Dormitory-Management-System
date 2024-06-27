import ReactDOM from 'react-dom/client'
import 'semantic-ui-css/semantic.min.css'
import { RouterProvider } from 'react-router-dom'
import { router } from './app/router/Routes'
import React from 'react'

const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);

root.render(
  <React.StrictMode>  
      <RouterProvider router={router} />
  </React.StrictMode>
);
