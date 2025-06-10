import React, { useState } from 'react';
import styles from '../../styles/AddProductPage.module.css';
import layoutStyles from '../../styles/AdminLayout.module.css';
import Sidebar from './Sidebar';
import Breadcrumbs from '../../components/ui/Breadcrumbs';

const AddProductPage = () => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [price, setPrice] = useState('');
  const [category, setCategory] = useState('');
  const [brand, setBrand] = useState('');
  const [discountPrice, setDiscountPrice] = useState('');
  const [size, setSize] = useState('');
  const [quantity, setQuantity] = useState(1);
  const [images, setImages] = useState([]);
  const [tags] = useState(['Lorem', 'Lorem', 'Lorem']);

  const productRequest = {
    name,
    description,
    price: parseFloat(price),
    category,
    size: parseInt(size),
  };

  const handleImageUpload = (e) => {
    const files = Array.from(e.target.files);
    setImages(files); // сохраним File объекты
  };

  const handleSave = async () => {
    const productRequest = {
      name,
      description,
      price: parseFloat(price),
      category,
      // другие поля по необходимости
    };

    try {
      const response = await fetch('https://localhost:7108/api/Product', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(productRequest),
      });

      if (response.ok) {
        const productId = await response.json();
        console.log('Product created with ID:', productId);
        alert('Товар успешно добавлен');
        // Здесь можно сбросить форму или перейти на другую страницу
      } else {
        const error = await response.text();
        console.error('Ошибка при создании товара:', error);
        alert('Ошибка при создании товара');
      }
    } catch (error) {
      console.error('Ошибка:', error);
      alert('Ошибка соединения с сервером');
    }
  };

  return (
      <div className={layoutStyles.dashboard}>
        <Sidebar />
        <div className={layoutStyles.contentWrapper}>
          <main className={styles.mainContent}>
            <div className={styles.formSection}>
              <h2 style={{ marginBottom: '0px' }}>Добавить товар</h2>
              <Breadcrumbs />

              <div className={styles.fieldGroup}>
                <label>Название товара</label>
                <input
                    type="text"
                    placeholder="Введите название товара"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
              </div>

              <div className={styles.fieldGroup}>
                <label>Описание</label>
                <textarea
                    placeholder="Введите описание здесь"
                    rows={4}
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
              </div>

              <div className={styles.fieldGroup}>
                <label>Категория</label>
                <select value={category} onChange={(e) => setCategory(e.target.value)}>
                  <option value="">Выберите категорию</option>
                  <option value="Одежда">Одежда</option>
                  <option value="Обувь">Обувь</option>
                  <option value="Обувь">test1</option>
                  <option value="Обувь">Перчатки</option>
                  <option value="Обувь">Носки))</option>
                </select>
              </div>

              <div className={styles.fieldGroup}>
                <label>Бренд</label>
                <input
                    type="text"
                    placeholder="Введите здесь название бренда"
                    value={brand}
                    onChange={(e) => setBrand(e.target.value)}
                />
              </div>

              <div className={styles.fieldRow}>
                <div className={styles.fieldGroup}>
                  <label>Цена</label>
                  <input
                      type="text"
                      placeholder="123.50 ₽"
                      value={price}
                      onChange={(e) => setPrice(e.target.value)}
                  />
                </div>

                <div className={styles.fieldGroup}>
                  <label>Цена со скидкой</label>
                  <input
                      type="text"
                      placeholder="123.50 ₽"
                      value={discountPrice}
                      onChange={(e) => setDiscountPrice(e.target.value)}
                  />
                </div>
              </div>

              <div className={styles.fieldRow}>
                <div className={styles.fieldGroup}>
                  <label>Размер:</label>
                  <select value={size} onChange={(e) => setSize(e.target.value)}>
                    <option value="">Выберите размер</option>
                    <option value="38">38</option>
                    <option value="39">39</option>
                    <option value="40">40</option>
                    <option value="41">41</option>
                    <option value="42">42</option>
                    <option value="43">43</option>
                    <option value="44">44</option>
                    <option value="45">45</option>
                    <option value="46">46</option>
                  </select>

                </div>

                <div className={styles.fieldGroup}>
                  <label>Количество</label>
                  <input
                      type="number"
                      value={quantity}
                      onChange={(e) => setQuantity(Number(e.target.value))}
                  />
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
                <button className={styles.saveBtn} onClick={handleSave}>
                  Сохранить
                </button>
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
                      <span>{img.name}</span>
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
