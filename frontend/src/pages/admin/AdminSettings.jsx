import React, { useState } from "react";
import Sidebar from "./Sidebar";
import Breadcrumbs from "../../components/ui/Breadcrumbs";
import layoutStyles from "../../styles/AdminLayout.module.css";
import styles from "../../styles/AdminSettings.module.css";
import {
  FiEdit,
  FiEye,
  FiEyeOff,
  FiUser,
  FiMail,
  FiLock,
  FiToggleLeft,
  FiToggleRight,
} from "react-icons/fi";

const AdminSettings = () => {
  // Состояние для показа/скрытия пароля и для 2FA
  const [showPassword, setShowPassword] = useState(false);
  const [twoFAEnabled, setTwoFAEnabled] = useState(false);

  // Примерные данные администраторов
  const admins = [
    {
      id: 1,
      name: "Андрей",
      email: "john@example.com",
      role: "Суперадмин",
      status: "Активен",
    },
    {
      id: 2,
      name: "Андрей",
      email: "john@example.com",
      role: "Контент-менеджер",
      status: "Активен",
    },
    {
      id: 3,
      name: "Андрей",
      email: "john@example.com",
      role: "Контент-менеджер",
      status: "Активен",
    },
    {
      id: 4,
      name: "Андрей",
      email: "john@example.com",
      role: "Контент-менеджер",
      status: "Активен",
    },
    {
      id: 5,
      name: "Андрей",
      email: "john@example.com",
      role: "Контент-менеджер",
      status: "Активен",
    },
  ];

  return (
    <div className={layoutStyles.dashboard}>
      {/* Левый сайдбар */}
      <Sidebar />

      {/* Основной контент */}
      <div className={layoutStyles.contentWrapper}>
        {/* Заголовок + Breadcrumbs */}
        <div className={styles.header}>
          <div>
            <h2 className={styles.pageTitle}>Настройки</h2>
            <Breadcrumbs />
          </div>
        </div>

        {/* ===== Управление аккаунтом администратора ===== */}
        <section className={styles.section}>
          <div className={styles.sectionTitle}>
            <FiUser className={styles.sectionIcon} />
            <span>Управление аккаунтом администратора</span>
          </div>

          {/* ---- Настройки профиля ---- */}
          <div className={styles.card}>
            <div className={styles.cardHeader}>Настройки профиля</div>
            <div className={styles.cardBody}>
              <div className={styles.inputGroup}>
                <label>Имя пользователя</label>
                <div className={styles.inputWithIcon}>
                  <input type="text" value="Andrei" readOnly />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>
              <div className={styles.inputGroup}>
                <label>Почта</label>
                <div className={styles.inputWithIcon}>
                  <input type="email" value="andrei22@gmail.com" readOnly />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>
              <div className={styles.buttonRow}>
                <button className={styles.primaryBtn}>Редактировать</button>
                <button className={styles.outlineBtn}>Сохранить</button>
              </div>
            </div>
          </div>

          {/* ---- Пароль ---- */}
          <div className={styles.card}>
            <div className={styles.cardHeader}>Пароль</div>
            <div className={styles.cardBody}>
              <div className={styles.inputGroup}>
                <label>Текущий пароль</label>
                <div className={styles.inputWithIcon}>
                  <input
                    type={showPassword ? "text" : "password"}
                    value="••••••••"
                    readOnly
                  />
                  <span
                    className={styles.eyeIcon}
                    onClick={() => setShowPassword(!showPassword)}
                  >
                    {showPassword ? <FiEyeOff /> : <FiEye />}
                  </span>
                </div>
              </div>
              <div className={styles.buttonRow}>
                <button className={styles.primaryBtn}>Изменить</button>
                <button className={styles.outlineBtn}>Сохранить</button>
              </div>
            </div>
          </div>

          {/* ---- Двухфакторная аутентификация ---- */}
          <div className={styles.card}>
            <div className={styles.cardHeader}>Двухфакторная аутентификация</div>
            <div className={styles.cardBody}>
              <div className={styles.toggleRow}>
                <span>Включить 2FA</span>
                <span
                  onClick={() => setTwoFAEnabled(!twoFAEnabled)}
                  className={styles.toggleIcon}
                >
                  {twoFAEnabled ? <FiToggleRight /> : <FiToggleLeft />}
                </span>
              </div>
            </div>
          </div>
        </section>

        {/* ===== Администраторы ===== */}
        <section className={styles.section}>
          <div className={styles.sectionTitle}>
            <FiUser className={styles.sectionIcon} />
            <span>Администраторы</span>
            <button className={styles.addAdminBtn}>Добавить администратора</button>
          </div>

          <div className={styles.card}>
            <table className={styles.adminsTable}>
              <thead>
                <tr>
                  <th>Имя</th>
                  <th>Почта</th>
                  <th>Роль</th>
                  <th>Статус</th>
                  <th>Действия</th>
                </tr>
              </thead>
              <tbody>
                {admins.map((admin) => (
                  <tr key={admin.id}>
                    <td>{admin.name}</td>
                    <td>{admin.email}</td>
                    <td>{admin.role}</td>
                    <td className={styles.statusActive}>{admin.status}</td>
                    <td>
                      <button className={styles.deleteBtn}>Удалить</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </section>

        {/* ===== Настройки магазина ===== */}
        <section className={styles.section}>
          <div className={styles.sectionTitle}>
            <FiEdit className={styles.sectionIcon} />
            <span>Настройки магазина</span>
          </div>

          <div className={styles.card}>
            <div className={styles.cardBody}>
              {/* --- Название магазина --- */}
              <div className={styles.inputGroup}>
                <label>Название магазина</label>
                <div className={styles.inputWithIcon}>
                  <input type="text" value="Patience" readOnly />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>

              {/* --- Логотип магазина --- */}
              <div className={styles.inputGroup}>
                <label>Логотип магазина</label>
                <div className={styles.imagePicker}>
                  <div className={styles.imagePreview}>100×100</div>
                  <button className={styles.uploadBtn}>Выберите изображение</button>
                </div>
              </div>

              {/* --- Значок --- */}
              <div className={styles.inputGroup}>
                <label>Значок</label>
                <div className={styles.imagePicker}>
                  <div className={styles.imagePreview}>100×100</div>
                  <button className={styles.uploadBtn}>Выберите изображение</button>
                </div>
              </div>

              {/* --- Контактная информация --- */}
              <div className={styles.inputGroup}>
                <label>Почта</label>
                <div className={styles.inputWithIcon}>
                  <input type="email" value="patience@gmail.com" readOnly />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>
              <div className={styles.inputGroup}>
                <label>Номер телефона</label>
                <div className={styles.inputWithIcon}>
                  <input type="text" value="+7 — — — — — — — —" readOnly />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>
              <div className={styles.inputGroup}>
                <label>Физический адрес</label>
                <textarea placeholder="Введите адрес" rows="3" />
              </div>

              {/* --- Ссылки на социальные сети --- */}
              <div className={styles.inputGroup}>
                <label>Instagram profile URL</label>
                <div className={styles.inputWithIcon}>
                  <input type="text" placeholder="Instagram profile URL" />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>
              <div className={styles.inputGroup}>
                <label>Telegram channel URL</label>
                <div className={styles.inputWithIcon}>
                  <input type="text" placeholder="Telegram channel URL" />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>
              <div className={styles.inputGroup}>
                <label>Facebook page URL</label>
                <div className={styles.inputWithIcon}>
                  <input type="text" placeholder="Facebook page URL" />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>
              <div className={styles.inputGroup}>
                <label>Custom social media URL</label>
                <div className={styles.inputWithIcon}>
                  <input type="text" placeholder="Custom social media URL" />
                  <FiEdit className={styles.editIcon} />
                </div>
              </div>

              {/* --- Рабочее время --- */}
              <div className={styles.workTimeGroup}>
                <label>Рабочее время</label>
                <div className={styles.timeRow}>
                  <span>Будни</span>
                  <input type="time" />
                  <span>—</span>
                  <input type="time" />
                </div>
                <div className={styles.timeRow}>
                  <span>Суббота</span>
                  <input type="time" />
                  <span>—</span>
                  <input type="time" />
                </div>
                <div className={styles.timeRow}>
                  <span>Воскресенье</span>
                  <input type="time" />
                  <span>—</span>
                  <input type="time" />
                </div>
              </div>

              {/* --- Кнопки внизу --- */}
              <div className={styles.buttonRow}>
                <button className={styles.primaryBtn}>Сохранить</button>
                <button className={styles.outlineBtn}>Отмена</button>
              </div>
            </div>
          </div>
        </section>
      </div>
    </div>
  );
};

export default AdminSettings;
