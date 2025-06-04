import React, { useState } from 'react';
import styles from '../../styles/AddProductPage.module.css';
import layoutStyles from '../../styles/AdminLayout.module.css';
import Sidebar from './Sidebar';
import Breadcrumbs from '../../components/ui/Breadcrumbs';

const AddProductPage = () => {
  const [images, setImages] = useState([]);
  const [tags] = useState(['Lorem', 'Lorem', 'Lorem']);

  const handleImageUpload = (e) => {
    const files = Array.from(e.target.files);
    setImages((prev) => [...prev, ...files.map((file) => file.name)]);
  };

  return (
    <div className={layoutStyles.dashboard}>
      <Sidebar />
      <div className={layoutStyles.contentWrapper}>
      <main className={styles.mainContent}>
        <div className={styles.formSection}>
          <h2 style={{marginBottom: '0px'}}>Добавить товар</h2>
          <Breadcrumbs />

          <div className={styles.fieldGroup}>
            <label>Название товара</label>
            <input type="text" placeholder="Введите название товара" />
          </div>

          <div className={styles.fieldGroup}>
            <label>Описание</label>
            <textarea placeholder="Введите описание здесь" rows={4} />
          </div>

          <div className={styles.fieldGroup}>
            <label>Категория</label>
            <select>
              <option>Выберите категорию</option>
            </select>
          </div>

          <div className={styles.fieldGroup}>
            <label>Бренд</label>
            <input type="text" placeholder="Введите здесь название бренда" />
          </div>

          <div className={styles.fieldRow}>
            <div className={styles.fieldGroup}>
              <label>Цена</label>
              <input type="text" placeholder="123.50 ₽" />
            </div>
            <div className={styles.fieldGroup}>
              <label>Цена со скидкой</label>
              <input type="text" placeholder="123.50 ₽" />
            </div>
          </div>

          <div className={styles.fieldRow}>
            <div className={styles.fieldGroup}>
              <label>Размер:</label>
              <select>
                <option>Выберите размер</option>
              </select>
            </div>
            <div className={styles.fieldGroup}>
              <label>Количество</label>
              <input type="number" defaultValue={1} />
            </div>
          </div>

          <div className={styles.fieldGroup}>
            <label>Тег</label>
            <div className={styles.tags}>
              {tags.map((tag, i) => (
                <span key={i} className={styles.tag}>{tag}</span>
              ))}
            </div>
          </div>

          <div className={styles.actions}>
            <button className={styles.deleteBtn}>Удалить</button>
            <button className={styles.saveBtn}>Сохранить</button>
          </div>
        </div>

        <div className={styles.gallerySection}>
          <div className={styles.thumbnailPreview}></div>

          <div className={styles.galleryUpload}>
            <input
              type="file"
              multiple
              onChange={handleImageUpload}
              style={{ display: 'none' }}
              id="fileInput"
            />
            <label htmlFor="fileInput" style={{ cursor: 'pointer' }}>
              Размещайте свои изображения здесь или просматривайте в формате jpeg, png
            </label>
          </div>

          <div className={styles.thumbnailList}>
            {images.map((img, i) => (
              <div key={i} className={styles.thumbnailItem}>
                <div className={styles.thumbnailPreview}></div>
                <span>{img}</span>
                <span className={styles.checkmark}>✔</span>
              </div>
            ))}
          </div>
        </div>
      </main>
      </div>
    </div>
  );
};

export default AddProductPage;
