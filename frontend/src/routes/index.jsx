import { Routes, Route } from 'react-router-dom';
import Home from '../pages/Home';
import Auth from '../pages/Auth';
import Catalog from '../pages/Catalog';
import Login from '../pages/Login';
import Brands from '../pages/Brands';
import ProductPage from '../pages/ProductPage';
import ScrollToTop from '../components/ScrollToTop';
import ProtectedRoute from "../components/ProtectedRoute";
import Cart from "../pages/Cart";
import Profile from "../pages/Profile";
import NewProducts from '../pages/NewProducts';
import AdminDashboard from '../pages/admin/AdminDashboard';

export const AppRoutes = () => {
  return (
    <>
      <ScrollToTop />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/auth" element={<Auth />} />
        <Route path="/catalog" element={<Catalog />} />
        <Route path="/login" element={<Login />} />
        <Route path="/brands" element={<Brands />} />
        <Route path="/catalog/:id" element={<ProductPage />} />
        <Route path="/new" element={<NewProducts />} />
        <Route path="/admin" element={
            <ProtectedRoute>
              <AdminDashboard />
            </ProtectedRoute>
          }
        />
        <Route path="/cart" element={
            <ProtectedRoute>
              <Cart />
            </ProtectedRoute>
          }
        />
        <Route path="/profile" element={
            <ProtectedRoute>
              <Profile />
            </ProtectedRoute>
          }
        />
      </Routes>
    </>
  );
};