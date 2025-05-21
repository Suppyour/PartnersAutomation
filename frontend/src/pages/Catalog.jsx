import React, { useState } from "react";
import styles from "../styles/Catalog.module.css";
import ProductCard from "../components/layout/ProductCard";
import Filters from "../components/ui/Filters";
import Breadcrumbs from "../components/ui/Breadcrumbs";
import productsData from "../data/Products";

function Catalog() {
  const [showFilters, setShowFilters] = useState(false);

  const [filters, setFilters] = useState({
    category: null,
    maxPrice: 10000,
    colors: [],
    sizes: [],
    style: null,
  });
  

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
          Показано {filteredProducts.length} из {productsData.length} товаров
        </div>
        <div className={styles.sort}>
          Сортировать по: <span>рейтингу</span>
        </div>
      </div>

      <div className={styles.mainContent}>
        {showFilters && (
          <div className={styles.sidebar}>
            <Filters onChange={handleFilterChange} />
          </div>
        )}

        <div className={styles.productsGrid}>
          {filteredProducts.map((product) => (
            <ProductCard key={product.id} product={product} />
          ))}
        </div>
      </div>
    </div>
  );
}

export default Catalog;
