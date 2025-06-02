import React, { useState } from 'react';
import styles from '../../styles/AdminDashboard.module.css';
import {
  FiHome,
  FiBox,
  FiShoppingCart,
  FiUsers,
  FiMessageSquare,
  FiBarChart2,
  FiSettings,
  FiCalendar,
  FiUser
} from 'react-icons/fi';
import Breadcrumbs from '../../components/ui/Breadcrumbs';
import Sidebar from './Sidebar';

const AdminDashboard = () => {
  return (
    <div className={styles.dashboard}>
      <Sidebar />
      <main className={styles.mainContent}>
        <header className={styles.header}>
          <div>
            <h2>Админ-панель</h2>
            <Breadcrumbs />
          </div>
          <div className={styles.dateAndUser}>
            <FiCalendar />
            <span> 11 нояб, 2024 — 11 окт, 2025</span>
            <span><FiUser /> Admin</span>
          </div>
        </header>

        <div className={styles.statsGrid}>
          {['Все заказы', 'Активные', 'Завершённые', 'Возвраты'].map(label => (
            <div key={label} className={styles.statCard}>
              <h4>{label}</h4>
              <p>126.500 ₽</p>
              <span><FiBarChart2 /> +34.7%</span>
              <small>По сравнению с октябрем 2023 года</small>
            </div>
          ))}
        </div>

        <div className={styles.graphSection}>
          <div className={styles.chartCard}>
            <h4>График продаж</h4>
            <div className={styles.tabButtons}>
              <button>НЕДЕЛЯ</button>
              <button className={styles.active}>МЕСЯЦ</button>
              <button>ГОД</button>
            </div>
            <div className={styles.fakeChart}>📈 Заглушка графика</div>
          </div>

          <div className={styles.popularCard}>
            <h4>Популярные товары</h4>
            {[1, 2, 3].map(i => (
              <div className={styles.popularItem} key={i}>
                <div className={styles.productImg}></div>
                <div>
                  <p>Lorem Ipsum</p>
                  <span>123.50 ₽ – 999 продаж</span>
                </div>
              </div>
            ))}
            <button className={styles.reportButton}>ОТЧЕТ</button>
          </div>
        </div>

        <div className={styles.ordersTable}>
          <h4>Последние заказы</h4>
          <table>
            <thead>
              <tr>
                <th></th>
                <th>Товар</th>
                <th>ID заказа</th>
                <th>Дата</th>
                <th>Имя клиента</th>
                <th>Статус</th>
                <th>Сумма</th>
              </tr>
            </thead>
            <tbody>
              {[...Array(6)].map((_, i) => (
                <tr key={i}>
                  <td><input type="checkbox" /></td>
                  <td>Lorem Ipsum</td>
                  <td>#2542{i}</td>
                  <td>8 ноября 2023 года</td>
                  <td><FiUser /> Клиент</td>
                  <td>{i % 2 === 0 ? '✅ Доставлено' : '❌ Отменено'}</td>
                  <td>500 ₽</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </main>
    </div>
  );
};

export default AdminDashboard;
