import React, { useState } from "react";
import styles from "../styles/Catalog.module.css";
import ProductCard from "../components/layout/ProductCard";
import Filters from "../components/ui/Filters";

import Breadcrumbs from "../components/ui/Breadcrumbs";
import products from "../data/Products";

function NewProducts() {
    const [showFilters, setShowFilters] = useState(false);

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
          <div className={styles.productCount}>Показано 1–{products.length} из {products.length} товаров</div>
          <div className={styles.sort}>Сортировать по: <span>рейтингу</span></div>
        </div>
  
        <div className={styles.mainContent}>
          {/* Фильтры как боковая панель */}
          {showFilters && (
            <div className={styles.sidebar}>
              <Filters />
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
  
  export default NewProducts;