import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import Register from "../components/authentication/RegisterPage"
import Login from "../components/authentication/LoginPage"


export const routes: RouteObject[] = [
    {
        path: "/",
        element: <App />,
        children: [
            {path: 'register', element: <Register />},
            {path: 'login', element: <Login />},
        ]
    },
]

export const router = createBrowserRouter(routes)
