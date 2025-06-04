import React from "react";
import styles from "../styles/Profile.module.css";
import products from "../data/Products";
import ProductCard from "../components/layout/ProductCard";
import { FiSettings, FiCreditCard, FiHeart, FiEdit2 } from "react-icons/fi";
import { Link } from "react-router-dom";

// Общий компонент для секций
const Section = ({ title, children }) => (
  <div className={styles.section}>
    <div className={styles.sectionTitle}>{title}</div>
    {children}
  </div>
);

// Карточка действия
const ActionCard = ({ icon, title, subtitle }) => (
  <button className={styles.actionCard}>
    <span className={styles.actionIcon}>{icon}</span>
    <div>
      <div>{title}</div>
      {subtitle && <div className={styles.actionSub}>{subtitle}</div>}
    </div>
  </button>
);

// Карточка сервиса
const ServiceCard = ({ icon, text }) => (
  <button className={styles.serviceCard}>
    <span className={styles.serviceIcon}>{icon}</span>
    {text}
  </button>
);

function Profile() {
  // Данные для ActionCard
  const actionCards = [
    { icon: <FiHeart />, title: "Избранное", subtitle: "9 товаров" },
    {
      icon: (
        <svg width="18" height="18" viewBox="0 0 18 18">
          <rect x="3" y="5" width="12" height="10" rx="2" fill="none" stroke="#222" strokeWidth="1.5" />
          <path d="M6 8h6" stroke="#222" strokeWidth="1.5" strokeLinecap="round" />
        </svg>
      ),
      title: "Покупки",
      subtitle: "Смотреть",
    },
    {
      icon: (
        <svg width="18" height="18" viewBox="0 0 18 18">
          <path
            d="M9 14.25A5.25 5.25 0 119 3.75a5.25 5.25 0 010 10.5zm0-9.5v4l2.5 1.5"
            stroke="#222"
            strokeWidth="1.5"
            fill="none"
            strokeLinecap="round"
          />
        </svg>
      ),
      title: "Ждут оценки",
      subtitle: "9 товаров",
    },
  ];

  // Данные для ServiceCard
  const serviceCards = [
    {
      icon: (
        <svg width="18" height="18" viewBox="0 0 18 18">
          <rect x="3" y="3" width="12" height="12" rx="3" stroke="#222" strokeWidth="1.4" fill="none" />
          <circle cx="9" cy="9" r="1.5" fill="#222" />
          <rect x="9" y="5" width="0.8" height="3" fill="#222" />
        </svg>
      ),
      text: "Написать в поддержку",
    },
    {
      icon: (
        <svg width="18" height="18" viewBox="0 0 18 18">
          <circle cx="9" cy="9" r="8" stroke="#222" strokeWidth="1.4" fill="none" />
          <circle cx="9" cy="13" r="1" fill="#222" />
          <path d="M9 5v2.5a1.5 1.5 0 001.5 1.5" stroke="#222" strokeWidth="1.4" fill="none" />
        </svg>
      ),
      text: "Вопросы и ответы",
    },
  ];

  return (
    <div className={styles.wrapper}>
      <div className={styles.topRow}>
        {/* Левая колонка */}
        <div className={styles.leftCol}>
          <div className={styles.profileCard}>
            <div className={styles.profileMain}>
              <div className={styles.avatar}>
                <svg width="36" height="36" viewBox="0 0 40 40">
                  <circle cx="20" cy="14" r="8" fill="#E6E6E6" />
                  <ellipse cx="20" cy="31" rx="12" ry="7" fill="#E6E6E6" />
                </svg>
              </div>
              <div className={styles.profileName}>Имя не указано</div>
              <button className={styles.profileArrow} aria-label="next">
                <svg width="18" height="18" viewBox="0 0 18 18">
                  <path d="M6 13l4-4-4-4" stroke="#222" strokeWidth="1.6" fill="none" strokeLinecap="round" strokeLinejoin="round" />
                </svg>
              </button>
              <button className={styles.profileBell} aria-label="notif">
                <svg width="22" height="22" viewBox="0 0 22 22">
                  <path
                    d="M11 19c1.1 0 2-.9 2-2H9a2 2 0 002 2zm6-4V10a6 6 0 10-12 0v5l-2 2v1h16v-1l-2-2z"
                    fill="#BDBDBD"
                  />
                </svg>
              </button>
            </div>
            {/* Секции */}
            <Section title="Финансы">
              <button className={styles.sectionBtn}>
                <span className={styles.sectionIcon}>
                  <FiCreditCard />
                </span>
                Способы оплаты
                <span className={styles.sectionEdit}>
                  <FiEdit2 />
                </span>
              </button>
            </Section>
            <Section title="Управление">
              <button className={styles.sectionBtn}>
                <span className={styles.sectionIcon}>
                  <FiSettings />
                </span>
                Настройки
              </button>
            </Section>
          </div>
        </div>

        {/* Правая колонка */}
        <div className={styles.rightCol}>
          <div className={styles.balanceCard}>
            <div className={styles.balanceInfo}>
              <span className={styles.balanceIcon}>
                <FiCreditCard />
              </span>
              <div>
                <div className={styles.balanceAmount}>100 ₽</div>
                <div className={styles.balanceLabel}>РТ Кошелёк</div>
              </div>
            </div>
            <button className={styles.topUpBtn}>Пополнить</button>
          </div>
          <div className={styles.actionCards}>
            {actionCards.map((card, index) => (
              <ActionCard key={index} {...card} />
            ))}
          </div>
          <div className={styles.serviceCards}>
            {serviceCards.map((card, index) => (
              <ServiceCard key={index} {...card} />
            ))}
          </div>
          <Link to={`/admin`}><button style={{width:"500px", height:"40px"}} >Админ-панель</button></Link>
          
        </div>
      </div>

      {/* Недавно просмотренные */}
      <div className={styles.recentlyViewedBlock}>
        <div className={styles.recentlyHeader}>
          <span>Недавно смотрели</span>
          <a href="#" className={styles.recentlyAll}>
            Все &gt;
          </a>
        </div>
        <div className={styles.productsGrid}>
          {products.map((product) => (
            <ProductCard key={product.id} product={product} />
          ))}
        </div>
      </div>
    </div>
  );
}

export default Profile;