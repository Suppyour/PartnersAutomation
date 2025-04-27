import React, { useState } from "react";
import styles from "../styles/ProductPage.module.css";
import { Heart } from "lucide-react";
import shirtImg from "../assets/products/shirt.png";
import Breadcrumbs from "../components/ui/Breadcrumbs";
import ProductDetails from "../components/ui/ProductDetails";
// import products from "../data/Products";

const ProductPage = () => {
  const [selectedColor, setSelectedColor] = useState("#4A4A4A");
  const [selectedSize, setSelectedSize] = useState("L");
  const [quantity, setQuantity] = useState(1);

  const colors = ["#4A4A4A", "#5E6141", "#1D253C"];
  const sizes = ["S", "M", "L", "XL"];

  return (
    <div className={styles.page}>
      {/* <div className={styles.breadcrumbs}>
        Главная &gt; Товары &gt; Повседневный стиль &gt; <span>Футболка</span>
      </div> */}
      <Breadcrumbs />

      <div className={styles.container}>
        
        <div className={styles.imagesSection}>
          <div className={styles.thumbnailList}>
            <img src={shirtImg} alt="thumb1" />
            <img src={shirtImg} alt="thumb2" />
            <img src={shirtImg} alt="thumb3" />
          </div>
          <div className={styles.mainImage}>
            <img src={shirtImg} alt="main" />
            <Heart size={20} className={styles.favoriteIcon} />
          </div>
        </div>

        <div className={styles.detailsSection}>
          <h1 className={styles.productName}>Футболка с рисунком One Life</h1>
          {/* <div className={styles.rating}>⭐⭐⭐⭐☆ <span>4.5/5</span></div> */}
          <div className={styles.priceBlock}>
            <span className={styles.price}>130₽</span>
            {/* <span className={styles.oldPrice}>160₽</span> */}
            {/* <span className={styles.discount}>-30%</span> */}
          </div>

          <p className={styles.description}>
            Эта футболка с графическим рисунком идеально подойдет для любого случая.
            Изготовленная из мягкой и дышащей ткани, она обеспечивает превосходный комфорт и стиль.
          </p>
          <div className={styles.hrWrapper}>
            <hr className={styles.hr} />
          </div>
          <div className={styles.colorSelector}>
            <p>Выберите цвета</p>
            <div className={styles.colors}>
              {colors.map((color) => (
                <span
                  key={color}
                  className={`${styles.colorCircle} ${selectedColor === color ? styles.selected : ""}`}
                  style={{ backgroundColor: color }}
                  onClick={() => setSelectedColor(color)}
                />
              ))}
            </div>
          </div>
          <div className={styles.hrWrapper}>
            <hr className={styles.hr} />
          </div>
          <div className={styles.sizeSelector}>
            <p>Выберите размер</p>
            <div className={styles.sizes}>
              {sizes.map((size) => (
                <button
                  key={size}
                  className={`${styles.sizeButton} ${selectedSize === size ? styles.selected : ""}`}
                  onClick={() => setSelectedSize(size)}
                >
                  {size}
                </button>
              ))}
            </div>
          </div>

          <div className={styles.actionRow}>
            <div className={styles.quantitySelector}>
              <button onClick={() => setQuantity(q => Math.max(1, q - 1))}>-</button>
              <span>{quantity}</span>
              <button onClick={() => setQuantity(q => q + 1)}>+</button>
            </div>
            <button className={styles.addToCart}>Добавить в корзину</button>
          </div>
        </div>
      </div>
      <ProductDetails />
    </div>
  );
};

export default ProductPage;
