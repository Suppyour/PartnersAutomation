import React, { useState } from 'react';
import styles from '../../styles/AddressModal.module.css';

const AddressModal = ({ onClose }) => {
  const [address, setAddress] = useState('');
  const [comment, setComment] = useState('');

  return (
    <div className={styles.modalWrapper}>
      <h3>Адрес доставки</h3>
      <input
        type="text"
        placeholder="Город, улица, дом"
        value={address}
        onChange={(e) => setAddress(e.target.value)}
        className={styles.input}
      />
      <textarea
        placeholder="Комментарий к доставке (необязательно)"
        value={comment}
        onChange={(e) => setComment(e.target.value)}
        className={styles.textarea}
      />
      <button className={styles.saveBtn} onClick={onClose}>Сохранить</button>
    </div>
  );
};

export default AddressModal;
