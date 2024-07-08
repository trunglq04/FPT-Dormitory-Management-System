import { BrowserRouter, Route, Routes } from 'react-router-dom'
import 'semantic-ui-css/semantic.min.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import HomePage from '../components/home/Home'
import Login from '../components/auth/Login'
import SignUp from '../components/auth/SignUp'

import ProtectedRoutes from '../utils/ProtectedRoutes'

function App() {
  // const location = useLocation();

  return ( 
    <BrowserRouter>
      <Routes>
        <Route element={<HomePage />} path="/" />
        <Route element={<Login />} path="/login" />
        <Route element={<SignUp />} path="/register" />
        <Route element={<ProtectedRoutes />}></Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
