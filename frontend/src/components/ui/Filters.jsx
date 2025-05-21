import React, { useState } from "react";
import styles from "../../styles/Filters.module.css";

function Filters({ onChange }) {
  const [filters, setFilters] = useState({
    category: null,
    maxPrice: 10000,
    colors: [],
    sizes: [],
    style: null,
  });

  const toggleItem = (arr, item) => {
    return arr.includes(item) ? arr.filter(i => i !== item) : [...arr, item];
  };

  const update = (updates) => {
    const newFilters = { ...filters, ...updates };
    setFilters(newFilters);
    onChange(newFilters);
  };

  const resetFilters = () => {
    const initial = {
      category: null,
      maxPrice: 10000,
      colors: [],
      sizes: [],
      style: null,
    };
    setFilters(initial);
    onChange(initial);
  };

  return (
    <aside className={styles.filters}>
      <div className={styles.section}>
        {["Футболки", "Шорты", "Рубашки", "Худи", "Джинсы"].map((cat) => (
          <h4
            key={cat}
            onClick={() => update({ category: cat })}
            className={filters.category === cat ? styles.active : ""}
          >
            {cat}
          </h4>
        ))}
      </div>

      <div className={styles.section}>
        <label>Цена до: {filters.maxPrice}₽</label>
        <input
          type="range"
          min="50"
          max="10000"
          value={filters.maxPrice}
          onChange={(e) => update({ maxPrice: parseInt(e.target.value) })}
          className={styles.slider}
        />
      </div>

      <div className={styles.section}>
        <label>Цвета</label>
        <div className={styles.colors}>
          {[
            { hex: "#f00", name: "Red" },
            { hex: "#ffa500", name: "Orange" },
            { hex: "#0f0", name: "Green" },
            { hex: "#0ff", name: "Cyan" },
            { hex: "#00f", name: "Blue" },
            { hex: "#f0f", name: "Magenta" },
            { hex: "#000", name: "Black" },
            { hex: "#fff", name: "White" },
          ].map(({ hex, name }) => (
            <span
              key={name}
              title={name}
              onClick={() => update({ colors: toggleItem(filters.colors, name) })}
              style={{ backgroundColor: hex }}
              className={`${styles.colorCircle} ${
                filters.colors.includes(name) ? styles.active : ""
              }`}
            />
          ))}
        </div>
      </div>

      <div className={styles.section}>
        <label>Размеры</label>
        <div className={styles.sizes}>
          {["XXS", "XS", "S", "M", "L", "XL", "XXL", "3XL", "4XL"].map((size) => (
            <button
              key={size}
              onClick={() => update({ sizes: toggleItem(filters.sizes, size) })}
              className={filters.sizes.includes(size) ? styles.active : ""}
            >
              {size}
            </button>
          ))}
        </div>
      </div>

      <div className={styles.section}>
        <label>Стиль одежды</label>
        <ul className={styles.styles}>
          {[
            { label: "Повседневный стиль", value: "casual" },
            { label: "Официальный/деловой стиль", value: "formal" },
            { label: "Нарядный стиль", value: "elegant" },
            { label: "Спортивный стиль", value: "sport" },
          ].map(({ label, value }) => (
            <li
              key={value}
              onClick={() => update({ style: value })}
              className={filters.style === value ? styles.active : ""}
            >
              {label}
            </li>
          ))}
        </ul>
      </div>

      <button className={styles.applyBtn} onClick={() => onChange(filters)}>Применить фильтр</button>
      <button className={styles.resetBtn} onClick={resetFilters}>Сбросить фильтры</button>
    </aside>
  );
}

export default Filters;

