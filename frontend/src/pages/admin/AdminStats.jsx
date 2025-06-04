import React from "react";
import Sidebar from "./Sidebar";
import Breadcrumbs from "../../components/ui/Breadcrumbs";
import layoutStyles from "../../styles/AdminLayout.module.css";
import styles from "../../styles/AdminStats.module.css";

import {
  FiDollarSign,
  FiShoppingCart,
  FiPackage,
  FiTrendingUp,
  FiPercent,
  FiCalendar,
} from "react-icons/fi";

import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  Tooltip,
  ResponsiveContainer,
  BarChart,
  Bar,
  CartesianGrid,
  Legend,
} from "recharts";

const AdminStats = () => {
  // 1) Данные для первых пяти карточек (верхняя часть)
  const cards = [
    {
      icon: <FiDollarSign size={20} />,
      title: "Общий доход",
      value: "126 500 ₽",
      subtitle: "по сравнению с предыдущим периодом",
    },
    {
      icon: <FiShoppingCart size={20} />,
      title: "Средняя стоимость заказа",
      value: "126 ₽",
      subtitle: "по сравнению с предыдущим периодом",
    },
    {
      icon: <FiPackage size={20} />,
      title: "Общее количество заказов",
      value: "1млн+",
      subtitle: "выполненные заказы",
    },
    {
      icon: <FiTrendingUp size={20} />,
      title: "Коэффициент конверсии",
      value: "4.5 %",
      subtitle: "от общего числа посетителей",
    },
    {
      icon: <FiPercent size={20} />,
      title: "Норма прибыли",
      value: "2.5 %",
      subtitle: "от общего количества заказов",
    },
  ];

  // 2) Данные для распределения по категориям (правый блок)
  const topCategories = [
    { label: "Мужчины", percent: 45 },
    { label: "Женщины", percent: 35 },
    { label: "Дети", percent: 20 },
  ];

  // 3) Данные для статистики возвратов
  const returnsData = [
    { label: "Неправильный размер", value: 155 },
    { label: "Дефект продукта", value: 89 },
    { label: "Не понравилось", value: 134 },
    { label: "Неправильный товар", value: 69 },
    { label: "Передумал", value: 112 },
  ];
  const totalReturns = returnsData.reduce((sum, item) => sum + item.value, 0);

  // 4) Данные для графика продаж (верхняя часть)
  const salesByMonth = [
    { month: "Янв", sales: 12000 },
    { month: "Фев", sales: 15000 },
    { month: "Мар", sales: 17000 },
    { month: "Апр", sales: 14000 },
    { month: "Май", sales: 18000 },
    { month: "Июн", sales: 16000 },
  ];

  // 5) Данные для графика «Продажи по категориям товаров»
  const salesByCategory = [
    { category: "Обувь", sales: 6000 },
    { category: "Одежда", sales: 9000 },
    { category: "Аксессуары", sales: 3000 },
    { category: "Спорт", sales: 4000 },
  ];

  // ========== НОВЫЕ ДАННЫЕ ДЛЯ ВТОРОЙ ПОЛОВИНЫ СТРАНИЦЫ ==========

  // 6) Данные для «Лучшие клиенты» (горизонтальный бар-чарт)
  const bestClients = [
    { name: "Элис Чен (USR-591)", orders: 120 },
    { name: "Виктор Иванов (USR-783)", orders: 100 },
    { name: "Мария Петрова (USR-412)", orders: 85 },
    { name: "Олег Сидоров (USR-330)", orders: 75 },
    { name: "Анна Смирнова (USR-904)", orders: 60 },
    { name: "Иван Кузнецов (USR-217)", orders: 50 },
    { name: "Екатерина Ли (USR-118)", orders: 45 },
    { name: "Дмитрий Орлов (USR-523)", orders: 40 },
    { name: "Светлана Белова (USR-812)", orders: 35 },
    { name: "Петр Захаров (USR-329)", orders: 30 },
  ];

  // 7) Данные для таблицы лучших клиентов (идентичные или похожие на график)
  const tableClients = bestClients.map((client, idx) => ({
    id: idx + 1,
    userId: client.name.split(" ")[1].replace("(", "").replace(")", ""),
    userName: client.name.split(" ")[0] + " " + client.name.split(" ")[1],
    orders: client.orders,
    totalRevenue: client.orders * 1000 + " ₽", // пример
    avgOrderValue: "8 000 ₽", // пример
  }));

  // 8) Данные для «Статистика по времени» (вертикальный бар-чарт, количество заказов по часам)
  const ordersByHour = [
    { hour: "00:00", value: 10 },
    { hour: "01:00", value: 15 },
    { hour: "02:00", value: 20 },
    { hour: "03:00", value: 25 },
    { hour: "04:00", value: 30 },
    { hour: "05:00", value: 35 },
    { hour: "06:00", value: 40 },
    { hour: "07:00", value: 45 },
    { hour: "08:00", value: 50 },
    { hour: "09:00", value: 60 },
    { hour: "10:00", value: 55 },
    { hour: "11:00", value: 50 },
    { hour: "12:00", value: 45 },
    { hour: "13:00", value: 60 },
    { hour: "14:00", value: 65 },
    { hour: "15:00", value: 70 },
    { hour: "16:00", value: 55 },
    { hour: "17:00", value: 50 },
    { hour: "18:00", value: 45 },
    { hour: "19:00", value: 60 },
    { hour: "20:00", value: 65 },
    { hour: "21:00", value: 70 },
    { hour: "22:00", value: 75 },
    { hour: "23:00", value: 80 },
  ];

  // 9) Данные для «Продажи по конкретному товару» (примерная выборка по часам)
  const productSalesByHour = [
    { hour: "00:00", value: 5 },
    { hour: "01:00", value: 8 },
    { hour: "02:00", value: 12 },
    { hour: "03:00", value: 20 },
    { hour: "04:00", value: 22 },
    { hour: "05:00", value: 25 },
    { hour: "06:00", value: 30 },
    { hour: "07:00", value: 35 },
    { hour: "08:00", value: 40 },
    { hour: "09:00", value: 50 },
    { hour: "10:00", value: 45 },
    { hour: "11:00", value: 40 },
    { hour: "12:00", value: 38 },
    { hour: "13:00", value: 50 },
    { hour: "14:00", value: 55 },
    { hour: "15:00", value: 60 },
    { hour: "16:00", value: 48 },
    { hour: "17:00", value: 45 },
    { hour: "18:00", value: 40 },
    { hour: "19:00", value: 55 },
    { hour: "20:00", value: 60 },
    { hour: "21:00", value: 65 },
    { hour: "22:00", value: 70 },
    { hour: "23:00", value: 75 },
  ];

  return (
    <div className={layoutStyles.dashboard}>
      {/* ===== Левый Sidebar ===== */}
      <Sidebar />

      {/* ===== Основной контент ===== */}
      <div className={layoutStyles.contentWrapper}>
        {/* Заголовок + Breadcrumbs + Дата */}
        <div className={styles.header}>
          <div>
            <h2 className={styles.title}>Статистика</h2>
            <Breadcrumbs />
          </div>
          <div className={styles.dateRange}>
            <FiCalendar size={18} />
            <span>11 нояб. 2024 — 11 окт. 2025</span>
          </div>
        </div>

        {/* ===== ПЕРВАЯ ПОЛОВИНА СТРАНИЦЫ: карточки и графики ===== */}
        <div className={styles.mainContent}>
          {/* Левая колонка */}
          <div className={styles.leftColumn}>
            {/* --- 1) Пять карточек сверху --- */}
            <div className={styles.cardsList}>
              {cards.map((card, idx) => (
                <div key={idx} className={styles.card}>
                  <div className={styles.cardIcon}>{card.icon}</div>
                  <div className={styles.cardInfo}>
                    <div className={styles.cardTitle}>{card.title}</div>
                    <div className={styles.cardValue}>{card.value}</div>
                    <div className={styles.cardSubtitle}>{card.subtitle}</div>
                  </div>
                </div>
              ))}
            </div>

            {/* --- 2) График продаж --- */}
            <div className={styles.chartContainer}>
              <div className={styles.chartHeader}>
                <h3>График продаж</h3>
                <div className={styles.chartTabs}>
                  <button className={styles.tabBtn}>Неделя</button>
                  <button className={`${styles.tabBtn} ${styles.activeTab}`}>Месяц</button>
                  <button className={styles.tabBtn}>Год</button>
                  <button className={styles.tabBtn}>Все время</button>
                </div>
              </div>
              <div style={{ width: "100%", height: 250 }}>
                <ResponsiveContainer>
                  <LineChart data={salesByMonth}>
                    <XAxis dataKey="month" />
                    <YAxis />
                    <Tooltip />
                    <Line
                      type="monotone"
                      dataKey="sales"
                      stroke="#5d5fef"
                      strokeWidth={3}
                    />
                  </LineChart>
                </ResponsiveContainer>
              </div>
            </div>

            {/* --- 3) Продажи по категориям товаров --- */}
            <div className={styles.chartContainer}>
              <div className={styles.chartHeader}>
                <h3>Продажи по категориям товаров</h3>
                <div className={styles.chartTabs}>
                  <button className={styles.tabBtn}>Неделя</button>
                  <button className={`${styles.tabBtn} ${styles.activeTab}`}>Месяц</button>
                  <button className={styles.tabBtn}>Год</button>
                </div>
              </div>
              <div style={{ width: "100%", height: 250 }}>
                <ResponsiveContainer>
                  <BarChart data={salesByCategory}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="category" />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Bar dataKey="sales" fill="#5d5fef" radius={[8, 8, 0, 0]} />
                  </BarChart>
                </ResponsiveContainer>
              </div>
            </div>
          </div>

          {/* Правая колонка */}
          <div className={styles.rightColumn}>
            {/* 4) Распределение продаж по категориям */}
            <div className={styles.topCategoriesBlock}>
              <h3>Распределение продаж по категориям</h3>
              <div className={styles.pieCircle}>100 %</div>
              <ul className={styles.topCategoriesList}>
                {topCategories.map((cat, idx) => (
                  <li key={idx}>
                    <span className={styles.catLabel}>{cat.label}</span>
                    <span className={styles.catPercent}>{cat.percent} %</span>
                  </li>
                ))}
              </ul>
            </div>

            {/* 5) Статистика возвратов по категориям */}
            <div className={styles.returnsBlock}>
              <h3>Статистика возвратов по категориям</h3>
              <ul className={styles.returnsList}>
                {returnsData.map((item, idx) => {
                  const percent = ((item.value / totalReturns) * 100).toFixed(0);
                  return (
                    <li key={idx} className={styles.returnItem}>
                      <div className={styles.returnLabel}>{item.label}</div>
                      <div className={styles.returnBar}>
                        <div
                          className={styles.returnFill}
                          style={{ width: `${percent}%` }}
                        />
                      </div>
                      <div className={styles.returnValue}>{item.value}</div>
                    </li>
                  );
                })}
              </ul>
              <div className={styles.totalReturns}>
                Общее количество возвратов: {totalReturns}
              </div>
            </div>
          </div>
        </div>

        {/* ===== ВТОРАЯ ПОЛОВИНА СТРАНИЦЫ: Поведенческий анализ ===== */}
        <div className={styles.behavioralSection}>
          <h3 className={styles.sectionTitle}>Поведенческий анализ</h3>

          {/* --- Блок «Лучшие клиенты» --- */}
          <div className={styles.bestClientsBlock}>
            <div className={styles.bestClientsHeader}>
              <span className={styles.bestClientsTitle}>Лучшие клиенты</span>
              <div className={styles.sortButtons}>
                <button className={`${styles.sortBtn} ${styles.activeSort}`}>По частоте</button>
                <button className={styles.sortBtn}>По выручке</button>
              </div>
            </div>

            {/* 6) Горизонтальный bar chart для лучших клиентов */}
            <div style={{ width: "100%", height: 300 }}>
              <ResponsiveContainer>
                <BarChart
                  data={bestClients}
                  layout="vertical"
                  margin={{ top: 20, right: 30, left: 100, bottom: 20 }}
                >
                  <XAxis type="number" hide />
                  <YAxis
                    type="category"
                    dataKey="name"
                    width={180}
                    tick={{ fontSize: 14 }}
                  />
                  <Tooltip />
                  <Bar dataKey="orders" fill="#5d5fef" barSize={14} />
                </BarChart>
              </ResponsiveContainer>
            </div>

            {/* 7) Таблица лучших клиентов */}
            <table className={styles.clientsTable}>
              <thead>
                <tr>
                  <th></th>
                  <th>ID пользователя</th>
                  <th>Имя пользователя</th>
                  <th>Заказы</th>
                  <th>Общий доход</th>
                  <th>Средняя стоимость заказа</th>
                </tr>
              </thead>
              <tbody>
                {tableClients.map((row, idx) => (
                  <tr key={idx}>
                    <td>
                      <input type="checkbox" />
                    </td>
                    <td>{row.userId}</td>
                    <td>{row.userName}</td>
                    <td>{row.orders}</td>
                    <td>{row.totalRevenue}</td>
                    <td>{row.avgOrderValue}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          {/* --- Блок «Статистика по времени» (заказы по часам) --- */}
          <div className={styles.timeStatsBlock}>
            <div className={styles.timeStatsHeader}>
              <span className={styles.timeStatsTitle}>Статистика по времени</span>
              <div className={styles.sortButtons}>
                <button className={styles.sortBtn}>Заказы</button>
                <button className={styles.sortBtn}>Продажи</button>
                <button className={`${styles.sortBtn} ${styles.activeSort}`}>День</button>
                <button className={styles.sortBtn}>Неделя</button>
                <button className={styles.sortBtn}>Месяц</button>
                <button className={styles.sortBtn}>Все время</button>
              </div>
            </div>
            <div style={{ width: "100%", height: 300 }}>
              <ResponsiveContainer>
                <BarChart
                  data={ordersByHour}
                  margin={{ top: 20, right: 30, left: 20, bottom: 5 }}
                >
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="hour" tick={{ fontSize: 12 }} />
                  <YAxis />
                  <Tooltip />
                  <Bar dataKey="value" fill="#5d5fef" />
                </BarChart>
              </ResponsiveContainer>
            </div>
          </div>

          {/* --- Блок «Продажи по конкретному товару» --- */}
          <div className={styles.productSalesBlock}>
            <div className={styles.productSalesHeader}>
              <input
                type="text"
                className={styles.productSearch}
                placeholder="Поиск товара"
              />
              <button className={styles.productSearchBtn}>Поиск</button>
            </div>
            <div className={styles.productName}>Футболка в полоску с рукавами</div>
            <div className={styles.productChartControls}>
              <button className={styles.sortBtn}>Выручка</button>
              <button className={`${styles.sortBtn} ${styles.activeSort}`}>
                Количество
              </button>
              <button className={styles.sortBtn}>День</button>
              <button className={styles.sortBtn}>Неделя</button>
            </div>
            <div style={{ width: "100%", height: 300 }}>
              <ResponsiveContainer>
                <BarChart
                  data={productSalesByHour}
                  margin={{ top: 20, right: 30, left: 20, bottom: 5 }}
                >
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="hour" tick={{ fontSize: 12 }} />
                  <YAxis />
                  <Tooltip />
                  <Bar dataKey="value" fill="#5d5fef" />
                </BarChart>
              </ResponsiveContainer>
            </div>
          </div>

          {/* --- Итоговые карточки внизу --- */}
          <div className={styles.bottomCards}>
            <div className={styles.summaryCard}>
              <div className={styles.summaryTitle}>Общий объём продаж</div>
              <div className={styles.summaryValue}>720</div>
            </div>
            <div className={styles.summaryCard}>
              <div className={styles.summaryTitle}>Доход</div>
              <div className={styles.summaryValue}>720</div>
            </div>
            <div className={styles.summaryCard}>
              <div className={styles.summaryTitle}>Сумма возвратов</div>
              <div className={styles.summaryValue}>63 000 ₽</div>
            </div>
            <div className={styles.summaryCard}>
              <div className={styles.summaryTitle}>Просмотры страниц</div>
              <div className={styles.summaryValue}>63 000</div>
            </div>
            <div className={styles.bottomCardRow}>
              <div className={styles.smallCard}>
                <div className={styles.smallTitle}>Возврат товара</div>
                <div className={styles.smallValue}>
                  100 ₽ <span className={styles.negative}>−3.2 %</span>
                </div>
              </div>
              <div className={styles.smallCard}>
                <div className={styles.smallTitle}>Рейтинг</div>
                <div className={styles.smallValue}>4.5 ★ ★ ★ ★ ★</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AdminStats;
