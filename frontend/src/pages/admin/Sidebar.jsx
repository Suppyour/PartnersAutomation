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
import { NavLink } from 'react-router-dom';

const Sidebar = () => {
  const [activeSection, setActiveSection] = useState('Главная');

  const menuItems = [
    { icon: <FiHome />, label: 'Главная', path: '/admin' },
    { icon: <FiBox />, label: 'Добавить товар', path: '/admin/add-product' },
    { icon: <FiShoppingCart />, label: 'Заказы', path: '/admin/orders' },
    { icon: <FiUsers />, label: 'Пользователи', path: '/admin/users' },
    { icon: <FiMessageSquare />, label: 'Отзывы', path: '/admin/reviews' },
    { icon: <FiBarChart2 />, label: 'Статистика', path: '/admin/stats' },
    { icon: <FiSettings />, label: 'Настройки', path: '/admin/settings' },
  ];

  return (
    <div className={styles.dashboard}>
      <aside className={styles.sidebar}>
        <div className={styles.logo}>
          <div className={styles.avatar}><FiUser /></div>
          <div className={styles.username}>Admin</div>
        </div>
        <nav className={styles.menu}>
          {menuItems.map((item) => (
            <NavLink
              key={item.label}
              to={item.path}
              className={({ isActive }) =>
                `${styles.menuItem} ${isActive ? styles.active : ''}`
              }
            >
              {item.icon}
              <span>{item.label}</span>
            </NavLink>
          ))}
        </nav>
      </aside>
    </div>
  );
};

export default Sidebar;