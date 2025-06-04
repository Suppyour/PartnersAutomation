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
import AddProductPage from '../pages/admin/AddProductPage';
import Sales from '../pages/Sales';
import AdminOrders from '../pages/admin/AdminOrders';
import AdminUsers from '../pages/admin/AdminUsers';
import AdminReviews from '../pages/admin/AdminReviews';
import AdminStats from '../pages/admin/AdminStats';
import AdminSettings from '../pages/admin/AdminSettings';

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
        <Route path="/sale" element={<Sales />} />
          <Route path="/admin" element={<AdminDashboard />} />
          <Route path="/admin/add_product" element={<AddProductPage />} />
          <Route path="/admin/orders" element={<AdminOrders />} />
          <Route path="/admin/users" element={<AdminUsers />} />
          <Route path="/admin/reviews" element={<AdminReviews />} />
          <Route path="/admin/stats" element={<AdminStats />} />
          <Route path="/admin/settings" element={<AdminSettings />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/cart" element={<Cart />} />
        {/* <Route path="/cart" element={
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
        /> */}
      </Routes>
    </>
  );
};