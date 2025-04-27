import React from "react";
import ProductCard from "./ProductCard";
import styles from "../../styles/Home.module.css";
import shirtImg from "../../assets/products/shirt.png";
import jeansImg from "../../assets/products/jeans.png";
import Products from "../../data/Products.jsx";

// const newArrivals = Array.from({ length: 4 }).map((_, i) => ({
//   id: i + 1,
//   name: "Футболка в полоску с рукавами",
//   category: "Футболки",
//   price: 130,
//   image: shirtImg,
// }));

// const discounts = Array.from({ length: 4 }).map((_, i) => ({
//   id: i + 1,
//   name: "Джинсы зауженного кроя",
//   category: "Джинсы",
//   price: 240,
//   image: jeansImg,
// }));

const ProductRow = ({ title, products }) => (
  <section className={styles.section}>
    <h2 className={styles.title}>{title}</h2>
    <div className={styles.row}>
      {products.map((p) => (
        <ProductCard key={p.id} product={p} />
      ))}
    </div>
    <div className={styles.buttonWrapper}>
      <button className={styles.button}>Посмотреть все</button>
    </div>
  </section>
);

const ProductShowcase = () => {
  return (
    <>
      <ProductRow title="Новое поступление" products={Products} />
      <div className={styles.hrWrapper}>
        <hr className={styles.hr} />
    </div>
      <ProductRow title="Товары со скидкой" products={Products} />
    </>
  );
};

export default ProductShowcase;

