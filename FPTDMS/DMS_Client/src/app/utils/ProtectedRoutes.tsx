import { Navigate } from 'react-router-dom'
import HomePage from '../components/home/Home'

const ProtectedRoutes = () => {
  const user = null
  return user ? <HomePage /> : <Navigate to="/login" />
}

export default ProtectedRoutes
