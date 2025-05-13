import { BrowserRouter } from 'react-router-dom';
import { AppRoutes } from './routes';
import { AuthProvider } from './context/AuthContext';
import Navbar from './components/layout/Navbar';
import Footer from './components/layout/Footer';

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Navbar />
        <AppRoutes />
        <Footer />      
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;