import React from 'react';
import styles from '../styles/Home.module.css'; // Импорт стилей
import { Link, useNavigate } from 'react-router-dom';
import fashionImage from '../assets/fashion-image.png';
import ProductShowcase from '../components/layout/ProductShowcase.jsx';

import versaceLogo from "../assets/logos/Versage.png";
import zaraLogo from "../assets/logos/Zara.png";
import gucciLogo from "../assets/logos/Gucci.png";
import pradaLogo from "../assets/logos/Prada.png";
import calvinKleinLogo from "../assets/logos/CalvinKlein.png";

const brandLogos = [
  { src: versaceLogo, alt: "Versace" },
  { src: zaraLogo, alt: "Zara" },
  { src: gucciLogo, alt: "Gucci" },
  { src: pradaLogo, alt: "Prada" },
  { src: calvinKleinLogo, alt: "Calvin Klein" },
];

const styleCategories = [
  {
    title: "Повседневный стиль",
    image: require("../assets/style/casual.jpg"),
    link: "/catalog?style=casual",
  },
  {
    title: "Официальный/ Деловой",
    image: require("../assets/style/business.jpg"),
    link: "/catalog?style=business",
  },
  {
    title: "Нарядный стиль",
    image: require("../assets/style/fancy.jpg"),
    link: "/catalog?style=fancy",
  },
  {
    title: "Спортивный стиль",
    image: require("../assets/style/sport.jpg"),
    link: "/catalog?style=sport",
  },
];
const Home = () => {
  const navigate = useNavigate();

  return (
    <div className={styles.container}>
    <section className={styles.fashionSection}>
      {/* <span className={`${styles.star} ${styles.topStar}`}>✦</span> */}
      {/* <span className={`${styles.star} ${styles.bottomStar}`}>✦</span> */}
      <div className={styles.fashionContainer}>
        {/* Левая часть — текст */}
        <div className={styles.fashionText}>
          <h1>Мода без переплат <br /> для тебя и твоей семьи</h1>
          <p>
            Ознакомьтесь с нашим разнообразным ассортиментом тщательно подобранной
            одежды, созданной для того, чтобы подчеркнуть вашу индивидуальность и
            удовлетворить ваше чувство стиля.
          </p>
          <Link to="/catalog" className={styles.fashionTextButton}>Смотреть товары</Link>
        </div>

        {/* Правая часть — изображение */}
        <div className={styles.fashionImageContainer}>
          <img src={fashionImage} alt="Fashion Models" className={styles.fashionImage} />
        </div>
      </div>
    </section>

    {/* Секция с брендами */}
    <section className={styles.brandsSection}>
      <div className={styles.brandsContainer}>
        {brandLogos.map((logo, index) => (
          <img
            key={index}
            src={logo.src}
            alt={logo.alt}
            className={styles.brandLogo}
          />
        ))}
      </div>
    </section>
    <ProductShowcase />
    <section className={styles.styleSection}>
        <h2>Выбирайте по стилю</h2>
        <div className={styles.grid}>
          {styleCategories.map((style) => (
            <div
              key={style.title}
              className={styles.card}
              onClick={() => navigate(style.link)}
            >
              <img src={style.image} alt={style.title} />
              <span className={styles.label}>{style.title}</span>
            </div>
          ))}
        </div>
      </section>
      {/* <button><Link to={`/admin`} className={styles.adminLink}>Admin</Link></button>  */}
      {/* Временно */}
    </div>
  );
};

export default Home;