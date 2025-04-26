import { BrowserRouter } from 'react-router-dom';
import { AppRoutes } from './routes';
import Navbar from './components/layout/Navbar';
import Footer from './components/layout/Footer';

function App() {
  return (
    <BrowserRouter>
      <Navbar />
      <AppRoutes />
      <Footer />
    </BrowserRouter>
  );
}

export default App;