import React from "react";
import { Link } from "react-router-dom";
import styles from "../../styles/ProductCard.module.css";

const ProductCard = ({ product }) => {
    return (
      <Link to={`/catalog/${product.id}`} className={styles.cardLink}>
        <div className={styles.card}>
          <img src={product.image} alt={product.name} className={styles.image} />
          <div className={styles.info}>
            <p className={styles.category}>{product.category}</p>
            <h3 className={styles.name}>{product.name}</h3>
            <p className={styles.price}>{product.price}₽</p>
          </div>
        </div>
      </Link>
    );
  };

export default ProductCard;
