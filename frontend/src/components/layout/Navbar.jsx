import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { FiSearch, FiChevronDown, FiShoppingCart, FiUser } from 'react-icons/fi';
import styles from '../../styles/Navbar.module.css';
import LOGO from '../../assets/logo.png';

const Navbar = () => {
  const [brandsOpen, setBrandsOpen] = useState(false);
  const [catalogOpen, setCatalogOpen] = useState(false);
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);
  const [searchQuery, setSearchQuery] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [isSearching, setIsSearching] = useState(false);
  const cartItemsCount = 0; // Пример количества товаров в корзине

  // Функция для выполнения поиска
  const handleSearch = async () => {
    if (!searchQuery.trim()) return;

    setIsSearching(true);
    try {
      const response = await fetch(`http://localhost:7108/api/Product/search`, {
        method: 'GET',
        headers: {
          'accept': 'text/plain',
        },
      });

      if (!response.ok) {
        throw new Error('Ошибка при поиске');
      }

      const data = await response.json();
      setSearchResults(data);
    } catch (error) {
      console.error('Ошибка:', error);
      setSearchResults([]);
    } finally {
      setIsSearching(false);
    }
  };

  // Обработка нажатия Enter в поле поиска
  const handleKeyPress = (e) => {
    if (e.key === 'Enter') {
      handleSearch();
    }
  };

  return (
      <nav className={styles.navbar}>
        <div className={styles.container}>
          {/* Логотип */}
          <Link to="/" className={styles.logo}><img src={LOGO} alt="" /></Link>

          {/* Бургер-меню для мобильных */}
          <div
              className={styles.burger}
              onClick={() => setMobileMenuOpen(!mobileMenuOpen)}
          >
            <div className={`${styles.burgerLine} ${mobileMenuOpen ? styles.open : ''}`}></div>
            <div className={`${styles.burgerLine} ${mobileMenuOpen ? styles.open : ''}`}></div>
            <div className={`${styles.burgerLine} ${mobileMenuOpen ? styles.open : ''}`}></div>
          </div>

          {/* Основное меню */}
          <div className={`${styles.menu} ${mobileMenuOpen ? styles.mobileActive : ''}`}>
            <div
                className={styles.menuItem}
                onMouseEnter={() => setCatalogOpen(true)}
                onMouseLeave={() => setCatalogOpen(false)}
            >
              <span>Каталог</span>
              <FiChevronDown className={styles.dropdownIcon} />
              {catalogOpen && (
                  <div className={styles.dropdown}>
                    <Link to="/catalog">Все товары</Link>
                    <Link to="#">Мужская одежда</Link>
                    <Link to="#">Женская одежда</Link>
                    <Link to="#">Детская одежда</Link>
                  </div>
              )}
            </div>

            <Link to="/sale" className={styles.menuItem}>Распродажа</Link>
            <Link to="/new" className={styles.menuItem}>Новинки</Link>

            <div
                className={styles.menuItem}
                onMouseEnter={() => setBrandsOpen(true)}
                onMouseLeave={() => setBrandsOpen(false)}
            >
              <span>Бренды</span>
              <FiChevronDown className={styles.dropdownIcon} />
              {brandsOpen && (
                  <div className={styles.dropdown}>
                    <Link to="/brands">Все бренды</Link>
                    <Link to="#">Бренд 1</Link>
                    <Link to="#">Бренд 2</Link>
                    <Link to="#">Бренд 3</Link>
                  </div>
              )}
            </div>

            {/* Поиск (скрывается на мобильных) */}
            <div className={styles.search}>
              <input
                  type="text"
                  placeholder="Поиск товаров"
                  value={searchQuery}
                  onChange={(e) => setSearchQuery(e.target.value)}
                  onKeyPress={handleKeyPress}
              />
              <FiSearch
                  className={styles.searchIcon}
                  onClick={handleSearch}
              />
            </div>

            {/* Результаты поиска (появляются под строкой поиска) */}
            {searchResults.length > 0 && (
                <div className={styles.searchResults}>
                  {searchResults.map((product) => (
                      <Link
                          key={product.id}
                          to={`/product/${product.id}`}
                          className={styles.resultItem}
                      >
                        {product.name}
                      </Link>
                  ))}
                </div>
            )}

            {/* Правая часть с иконками */}
            <div className={styles.icons}>
              <Link to="/cart" className={styles.cartIcon}>
                <FiShoppingCart />
                {cartItemsCount > 0 && (
                    <span className={styles.cartBadge}>{cartItemsCount}</span>
                )}
              </Link>
              <Link to="/auth" className={styles.userIcon}>
                <FiUser />
              </Link>
            </div>
          </div>
        </div>
      </nav>
  );
};

export default Navbar;