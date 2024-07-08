import { BrowserRouter, Route, Routes } from 'react-router-dom'
import 'semantic-ui-css/semantic.min.css'
import HomePage from '../components/home/Home'
import LoginPage from '../components/auth/Login'
import ProtectedRoutes from '../utils/ProtectedRoutes'

function App() {
  // const location = useLocation();

  return (
    <BrowserRouter>
      <Routes>
        <Route element={<HomePage />} path="/" />
        <Route element={<LoginPage />} path="/login" />
        <Route element={<RegisterPage />} path="/register" />
        <Route element={<ProtectedRoutes />}></Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
