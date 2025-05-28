import React, { useState, useEffect } from "react";
import styles from "../styles/Catalog.module.css";
import ProductCard from "../components/layout/ProductCard";
import Filters from "../components/ui/Filters";
import Breadcrumbs from "../components/ui/Breadcrumbs";
import productsData from "../data/Products";
import { getProducts, searchProducts } from "../api/productService.js";

function Catalog() {
    const [showFilters, setShowFilters] = useState(false);
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

  const [filters, setFilters] = useState({
    category: null,
    maxPrice: 10000,
    colors: [],
    sizes: [],
    style: null,
  });
  
    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const data = await getProducts();
                setProducts(data);
                setLoading(false);
            } catch (err) {
                setError(err.message);
                setLoading(false);
            }
        };

        fetchProducts();
    }, []);
    
  const handleFilterChange = (newFilters) => {
    setFilters((prev) => ({ ...prev, ...newFilters }));
  };

  const filteredProducts = productsData.filter((product) => {
    return (
      (!filters.category || product.category === filters.category) &&
      product.price <= filters.maxPrice &&
      (filters.colors.length === 0 || filters.colors.includes(product.color)) &&
      (filters.sizes.length === 0 || filters.sizes.includes(product.size)) &&
      (!filters.style || product.style === filters.style)
    );
  });

  const handleSearch = async (searchTerm) => {
      try {
          setLoading(true);
          const data = await searchProducts(searchTerm);
          setProducts(data);
          setLoading(false);
      } catch (err) {
          setError(err.message);
          setLoading(false);
      }
  };
  if (loading) {
      return <div className={styles.catalogPage}>Loading...</div>;
  }
  if (error) {
      return <div className={styles.catalogPage}>Error: {error}</div>;
  }  
  return (
      <div className={styles.catalogPage}>
          <Breadcrumbs />
          <div className={styles.topRow}>
              <button
                  className={styles.filterButton}
                  onClick={() => setShowFilters(!showFilters)}
              >
                  Фильтры
              </button>
              <div className={styles.productCount}>
                  Показано 1–{products.length} из {products.length} товаров
              </div>
              <div className={styles.sort}>
                  Сортировать по: <span>рейтингу</span>
              </div>
          </div>
          <div className={styles.mainContent}>
              {showFilters && (
                  <div className={styles.sidebar}>
                      <Filters onSearch={handleSearch} />
                  </div>
              )}
              <div className={styles.productsGrid}>
                  {products.map((product) => (
                      <ProductCard key={product.id} product={product} />
                  ))}
              </div>
          </div>
      </div>
  );
}

export default Catalog;
