import { RouteObject, createBrowserRouter } from 'react-router-dom'
import App from '../layout/App'
import Register from '../components/auth/SignUp'
import Login from '../components/auth/Login'

export const routes: RouteObject[] = [
  {
    path: '/',
    element: <App />,
    children: [
      { path: 'register', element: <Register /> },
      { path: 'login', element: <Login /> },
    ],
  },
]

export const router = createBrowserRouter(routes)
