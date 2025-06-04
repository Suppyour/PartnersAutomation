import React, { useState } from "react";
import Sidebar from "./Sidebar";
import Breadcrumbs from "../../components/ui/Breadcrumbs";
import layoutStyles from "../../styles/AdminLayout.module.css";
import styles from "../../styles/AdminUsers.module.css";
import { FiCalendar } from "react-icons/fi";

const statuses = ["active", "Pending", "Banned", "inactive"];

const mockUsers = Array.from({ length: 16 }).map((_, i) => ({
  name: "Иванов И.И",
  email: "emma.q@email.com",
  status: statuses[i % statuses.length],
  role: ["Покупатель", "Менеджер", "Гость", "Администратор"][i % 4],
  registered: "2023-11-20",
  lastLogin: "2024-02-21 11:45",
  total: i % 3 === 0 ? "126.500 ₽" : "0",
}));

const AdminUsers = () => {
  const [search, setSearch] = useState("");

  const filtered = mockUsers.filter((user) =>
    user.name.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className={layoutStyles.dashboard}>
      <Sidebar />
      <div className={layoutStyles.contentWrapper}>
        <main className={styles.usersPage}>
          <div className={styles.header}>
            <div>
              <h2>Управление пользователями</h2>
              <Breadcrumbs />
            </div>
            <div className={styles.dateRange}>
              <FiCalendar />
              <span>11 ноябр, 2024 — 11 октябр, 2025</span>
            </div>
          </div>

          <div className={styles.controls}>
            <input
              type="text"
              placeholder="🔍 Поиск"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
            />
            <button className={styles.exportBtn}>📤 Export</button>
            <select>
              <option>Роль</option>
              <option>Покупатель</option>
              <option>Менеджер</option>
              <option>Администратор</option>
              <option>Гость</option>
            </select>
            <select>
              <option>Активные</option>
              <option>Все</option>
              <option>Banned</option>
              <option>Inactive</option>
            </select>
          </div>

          <table className={styles.usersTable}>
            <thead>
              <tr>
                <th>Имя пользователя</th>
                <th>Email</th>
                <th>Статус</th>
                <th>Роль</th>
                <th>Дата регистрации</th>
                <th>Последний вход</th>
                <th>Общая сумма покупок</th>
              </tr>
            </thead>
            <tbody>
              {filtered.map((user, i) => (
                <tr key={i}>
                  <td>{user.name}</td>
                  <td>{user.email}</td>
                  <td>
                    <span className={`${styles.status} ${styles[user.status]}`}>
                      {user.status}
                    </span>
                  </td>
                  <td>{user.role}</td>
                  <td>{user.registered}</td>
                  <td>{user.lastLogin}</td>
                  <td>{user.total}</td>
                </tr>
              ))}
            </tbody>
          </table>

          <div className={styles.pagination}>
            <button className={styles.active}>1</button>
            <button>2</button>
            <button>3</button>
            <button>4</button>
            <span>...</span>
            <button>10</button>
            <button>СЛЕДУЮЩИЙ &gt;</button>
          </div>
        </main>
      </div>
    </div>
  );
};

export default AdminUsers;
