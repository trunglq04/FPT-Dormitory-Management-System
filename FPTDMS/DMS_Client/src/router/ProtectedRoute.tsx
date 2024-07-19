import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';

const ProtectedRoute: React.FC = () => {
  const isAuthenticated = !!localStorage.getItem('access_token');
  
  return isAuthenticated ? <Outlet /> : <Navigate to="/home" />;
};

export default ProtectedRoute;
