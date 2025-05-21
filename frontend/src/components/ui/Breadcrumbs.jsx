import React from "react";
import { useLocation, Link } from "react-router-dom";
import styles from "../../styles/Breadcrumbs.module.css";

// Словарь "машинное → человекочитаемое"
const breadcrumbMap = {
  catalog: "Каталог",
  tshirts: "Футболки",
  shorts: "Шорты",
  shirts: "Рубашки",
  hoodies: "Худи",
  jeans: "Джинсы",
  sale: "Распродажа",
  brands: "Бренды",
  news: "Новинки",
  admin: "Панель администратора",
//   product.id: product.name,
};

function Breadcrumbs() {
  const location = useLocation();
  const pathnames = location.pathname.split("/").filter((x) => x);

  return (
    <nav className={styles.breadcrumbs}>
      <Link to="/">Главная</Link>
      {pathnames.map((value, index) => {
        const to = "/" + pathnames.slice(0, index + 1).join("/");
        const isLast = index === pathnames.length - 1;
        const displayName = breadcrumbMap[value] || decodeURIComponent(value);

        return isLast ? (
          <span key={to}> &gt; <span>{displayName}</span></span>
        ) : (
          <span key={to}> &gt; <Link to={to}>{displayName}</Link></span>
        );
      })}
    </nav>
  );
}

export default Breadcrumbs;

