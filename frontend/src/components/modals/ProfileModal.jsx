import React, { useState } from 'react';
import styles from '../../styles/ProfileModal.module.css';

const ProfileModal = ({ onClose }) => {
  const [phone, setPhone] = useState('');
  const [name, setName] = useState('');

  return (
    <div className={styles.modalWrapper}>
      <h3>Мои данные</h3>
      <input
        type="text"
        placeholder="Имя"
        value={name}
        onChange={(e) => setName(e.target.value)}
        className={styles.input}
      />
      <input
        type="tel"
        placeholder="+7 (___) ___-__-__"
        value={phone}
        onChange={(e) => setPhone(e.target.value)}
        className={styles.input}
      />
      <button className={styles.saveBtn} onClick={onClose}>Сохранить</button>
    </div>
  );
};

export default ProfileModal;
