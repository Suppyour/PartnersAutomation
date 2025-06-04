import React, { useState } from "react";
import Sidebar from "./Sidebar";
import Breadcrumbs from "../../components/ui/Breadcrumbs";
import layoutStyles from "../../styles/AdminLayout.module.css";
import styles from "../../styles/AdminUsers.module.css"; // Используем те же стили
import { FiCalendar } from "react-icons/fi";

const statuses = ["Обработан", "В пути", "Доставлен", "Отменен"];

const mockOrders = Array.from({ length: 16 }).map((_, i) => ({
  id: `#ORD-${1000 + i}`,
  name: "Иванов И.И",
  email: "user@email.com",
  date: "2024-04-12",
  status: statuses[i % statuses.length],
  total: "12 500 ₽",
}));

const AdminOrders = () => {
  const [search, setSearch] = useState("");

  const filtered = mockOrders.filter((order) =>
    order.name.toLowerCase().includes(search.toLowerCase()) ||
    order.id.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className={layoutStyles.dashboard}>
      <Sidebar />
      <div className={layoutStyles.contentWrapper}>
        <main className={styles.usersPage}>
          <div className={styles.header}>
            <div>
              <h2>Управление заказами</h2>
              <Breadcrumbs />
            </div>
            <div className={styles.dateRange}>
              <FiCalendar />
              <span>01 янв, 2024 — 01 июн, 2025</span>
            </div>
          </div>

          <div className={styles.controls}>
            <input
              type="text"
              placeholder="🔍 Поиск по имени или номеру"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
            />
            <button className={styles.exportBtn}>📤 Export</button>
            <select>
              <option>Статус</option>
              {statuses.map((s) => (
                <option key={s}>{s}</option>
              ))}
            </select>
          </div>

          <table className={styles.usersTable}>
            <thead>
              <tr>
                <th>Номер заказа</th>
                <th>Имя клиента</th>
                <th>Email</th>
                <th>Дата</th>
                <th>Статус</th>
                <th>Сумма</th>
              </tr>
            </thead>
            <tbody>
              {filtered.map((order, i) => (
                <tr key={i}>
                  <td>{order.id}</td>
                  <td>{order.name}</td>
                  <td>{order.email}</td>
                  <td>{order.date}</td>
                  <td>
                    <span
                      className={`${styles.status} ${
                        styles[
                          order.status === "Обработан"
                            ? "active"
                            : order.status === "В пути"
                            ? "Pending"
                            : order.status === "Доставлен"
                            ? "inactive"
                            : "Banned"
                        ]
                      }`}
                    >
                      {order.status}
                    </span>
                  </td>
                  <td>{order.total}</td>
                </tr>
              ))}
            </tbody>
          </table>

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

export default AdminOrders;

