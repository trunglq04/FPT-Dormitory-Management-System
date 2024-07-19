import HomePageContent from "../../features/home/HomePageContent";
import { Route, Routes } from "react-router-dom";
import About from "../../features/home/About";
import DashBoard from "../../user/DashBoard/DashBoard";
import RegisterPage from "../../user/RegisterPage";
import ProtectedRoute from "../../router/ProtectedRoute";
import BookingBed from "../../user/DashBoard/BookingBed";
import ForgotPassword from "../../user/ForgotPassword";
import Verify from "../../user/Verify";
import ResetPassword from "../../user/ResetPassword";
import "../../assets/css/App.css";
// import DormSelection from '../../features/content/DormSelection';
// import SideBar from '../../features/sidebar/SideBar';
import CompleteProfilePage from "../../user/CompleteProfilePage";
import AdminDashBoard from "../../admin/admin";
import UserManagement from "../../admin/userManagement";
import HouseManagement from "../../admin/houseManagement";
import RoomManagement from "../../admin/roomManagement";
import BookingManagement from "../../admin/bookingManagement";
import PaymentHistory from "../../admin/userManagement";
import UserProfile from "../../user/DashBoard/UserProfile";
import ChatDemo from "../../features/Chat/ChatDemo";
import UserPayementHistory from "../../user/DashBoard/UserPaymentHistory";
import ServiceManagement from "../../admin/serviceManagement";
import Service from "../../user/DashBoard/Service";
import ServiceRequest from "../../admin/serviceRequest";
function App() {
  return (
    <div className="no-padding no-margin">
      <Routes>
        <Route path="" element={<HomePageContent />}></Route>
        <Route path="/about-us" element={<About />}></Route>
        
        {/* User Routes */}
        <Route path="/user" element={<ProtectedRoute />}>
          <Route path="dashboard" element={<DashBoard />} />
          <Route path="booking-bed" element={<BookingBed />} />
          <Route path="service" element={<Service />} />
          <Route path="payments" element={<UserPayementHistory />} />
          <Route path="profile/:id" element={<UserProfile />} />
        </Route>

        <Route path="register" element={<RegisterPage />}></Route>
        <Route path="/complete-profile/:id" element={<CompleteProfilePage />} />
        <Route path="forgot-password" element={<ForgotPassword />}></Route>
        <Route path="verify" element={<Verify />}></Route>
        <Route path="reset-password" element={<ResetPassword />}></Route>
        <Route path="/admin" element={<AdminDashBoard />}>
          <Route path="users" element={<UserManagement />} />
          <Route path="houses" element={<HouseManagement />} />
          <Route path="rooms" element={<RoomManagement />} />
          <Route path="bookings" element={<BookingManagement />} />
          <Route path="payments" element={<PaymentHistory />} />
          <Route path = "services" element={<ServiceManagement />} /> 
          <Route path="service-request" element={<ServiceRequest />}></Route>
        </Route>
        <Route path="chat-demo" element={<ChatDemo />}></Route>
        <Route path="*" element={<HomePageContent />}></Route>
      </Routes>
    </div>
  );
}

export default App;
