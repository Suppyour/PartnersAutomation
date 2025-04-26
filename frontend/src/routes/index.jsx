import { Routes, Route, Router } from 'react-router-dom';
import Home from '../pages/Home';
import Auth from '../pages/Auth';
import Catalog from '../pages/Catalog';
import Login from '../pages/Login';
import Brands from '../pages/Brands';
import ProductPage from '../pages/ProductPage';
import ScrollToTop from '../components/ScrollToTop';

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
      </Routes>
    </>

  );
};