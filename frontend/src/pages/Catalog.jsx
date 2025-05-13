import React, { useState } from "react";
import styles from "../styles/Catalog.module.css";
import ProductCard from "../components/layout/ProductCard";
import Filters from "../components/ui/Filters";
// import shirtImg from "../assets/products/shirt.png";
// import { Link } from "react-router-dom";
import Breadcrumbs from "../components/ui/Breadcrumbs";
import products from "../data/Products";

// const mockProducts = Array.from({ length: 20 }).map((_, i) => ({
//   id: i + 1,
//   name: "Футболка в полоску с рукавами",
//   category: "Футболки",
//   price: 130,
//   image: shirtImg,
// }));

function Catalog() {
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

export default Catalog;

