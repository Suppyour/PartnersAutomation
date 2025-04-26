import React from "react";
import styles from "../../styles/Filters.module.css";

function Filters() {
  return (
    <aside className={styles.filters}>
      <div className={styles.section}>
        <h4>Футболки</h4>
        <h4>Шорты</h4>
        <h4>Рубашки</h4>
        <h4>Худи</h4>
        <h4>Джинсы</h4>
      </div>

      <div className={styles.section}>
        <label>Цена</label>
        <input type="range" min="50" max="2000" className={styles.slider} />
      </div>

      <div className={styles.section}>
        <label>Цвета</label>
        <div className={styles.colors}>
          {["#f00", "#ffa500", "#0f0", "#0ff", "#00f", "#f0f", "#000", "#fff"].map((color, i) => (
            <span key={i} style={{ backgroundColor: color }} className={styles.colorCircle}></span>
          ))}
        </div>
      </div>

      <div className={styles.section}>
        <label>Размеры</label>
        <div className={styles.sizes}>
          {["XXS", "XS", "S", "M", "L", "XL", "XXL", "3XL", "4XL"].map((size) => (
            <button key={size}>{size}</button>
          ))}
        </div>
      </div>

      <div className={styles.section}>
        <label>Стиль одежды</label>
        <ul className={styles.styles}>
          <li>Повседневный стиль</li>
          <li>Официальный/деловой стиль</li>
          <li>Нарядный стиль</li>
          <li>Спортивный стиль</li>
        </ul>
      </div>

      <button className={styles.applyBtn}>Применить фильтр</button>
    </aside>
  );
}

export default Filters;
