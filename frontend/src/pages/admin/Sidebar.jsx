import React from 'react';
import { NavLink } from 'react-router-dom';
import { FiHome, FiBox, FiShoppingCart, FiUsers, FiMessageSquare, FiBarChart2, FiSettings, FiUser } from 'react-icons/fi';
import styles from '../../styles/AdminLayout.module.css';

const Sidebar = () => {
  const menuItems = [
    { icon: <FiHome />, label: 'Главная', path: '/admin' },
    { icon: <FiBox />, label: 'Добавить товар', path: '/admin/add_product' },
    { icon: <FiShoppingCart />, label: 'Заказы', path: '/admin/orders' },
    { icon: <FiUsers />, label: 'Пользователи', path: '/admin/users' },
    { icon: <FiMessageSquare />, label: 'Отзывы', path: '/admin/reviews' },
    { icon: <FiBarChart2 />, label: 'Статистика', path: '/admin/stats' },
    { icon: <FiSettings />, label: 'Настройки', path: '/admin/settings' },
  ];

  return (
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
  );
};

export default Sidebar;

