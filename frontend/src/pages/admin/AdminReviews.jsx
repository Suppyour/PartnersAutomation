import React, { useState } from "react";
import Sidebar from "./Sidebar";
import Breadcrumbs from "../../components/ui/Breadcrumbs";
import layoutStyles from "../../styles/AdminLayout.module.css";
import styles from "../../styles/AdminReviews.module.css";
import { FiCalendar } from "react-icons/fi";

const mockReviews = Array.from({ length: 12 }).map((_, i) => ({
  user: "Сара Миллер",
  product: "Винтажная джинсовка",
  text: "Прекрасное состояние, в точности как описано!",
  date: "2024-01-15",
  rating: 5 - (i % 3),
  status: ["На модерации", "Опубликован", "Отклонён", "Спам"][i % 4],
}));

const AdminReviews = () => {
  const [search, setSearch] = useState("");

  const filtered = mockReviews.filter((review) =>
    review.user.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className={layoutStyles.dashboard}>
      <Sidebar />
      <div className={layoutStyles.contentWrapper}>
        <main className={styles.reviewsPage}>
          <div className={styles.header}>
            <div>
              <h2>Управление отзывами</h2>
              <Breadcrumbs />
            </div>
            <div className={styles.dateRange}>
              <FiCalendar />
              <span>11 ноябр. 2024 — 11 октябрь 2025</span>
            </div>
          </div>

          <div className={styles.controls}>
            <input
              type="text"
              placeholder="🔍 Поиск по имени"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
            />
            <button className={styles.exportBtn}>📤 Export</button>
            <select>
              <option>Товар</option>
              <option>Джинсовка Nike</option>
            </select>
            <select>
              <option>Статус</option>
              <option>Опубликован</option>
              <option>На модерации</option>
              <option>Отклонён</option>
              <option>Спам</option>
            </select>
            <input type="date" />
            <select>
              <option>★★★★☆ и выше</option>
              <option>★★★☆☆ и выше</option>
              <option>★★☆☆☆ и выше</option>
            </select>
          </div>

          <ul className={styles.reviewList}>
            {filtered.map((review, i) => (
              <li key={i} className={styles.reviewItem}>
                <div className={styles.reviewHeader}>
                  <span className={styles.user}>{review.user}</span>
                  <span className={styles.product}>{review.product}</span>
                </div>
                <p className={styles.text}>{review.text}</p>
                <div className={styles.meta}>
                  <span>{review.date}</span>
                  <span className={`${styles.status} ${styles[review.status.toLowerCase()]}`}>
                    {review.status}
                  </span>
                  <span className={styles.stars}>
                    {"★".repeat(review.rating)}{"☆".repeat(5 - review.rating)}
                  </span>
                </div>
                <div className={styles.actions}>
                  <button className={styles.danger}>🗑️</button>
                  <button className={styles.warning}>❗</button>
                  <button className={styles.edit}>Редактировать</button>
                  <button className={styles.approve}>Одобрить</button>
                  <button className={styles.reject}>Отклонить</button>
                </div>
              </li>
            ))}
          </ul>

          <div className={styles.pagination}>
            <button className={styles.active}>1</button>
            <button>2</button>
            <button>3</button>
            <button>...</button>
            <button>10</button>
            <button>СЛЕДУЮЩИЙ &gt;</button>
          </div>
        </main>
      </div>
    </div>
  );
};

export default AdminReviews;
