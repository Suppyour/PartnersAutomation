import React, { useState } from 'react';
import styles from '../../styles/PaymentModal.module.css';

const PaymentModal = ({ onClose }) => {
  const [selected, setSelected] = useState('wallet');

  return (
    <div className={styles.modalWrapper}>
      <h3>Способ оплаты</h3>

      <label className={styles.option}>
        <input
          type="radio"
          name="payment"
          value="wallet"
          checked={selected === 'wallet'}
          onChange={() => setSelected('wallet')}
        />
        <span>🪙 РТ Кошелёк: 100 ₽</span>
      </label>

      <label className={styles.option}>
        <input
          type="radio"
          name="payment"
          value="credit"
          checked={selected === 'credit'}
          onChange={() => setSelected('credit')}
        />
        <div>
          <span>💳 Кредит</span>
          <p className={styles.hint}>Заполните анкету и выберите банк</p>
        </div>
      </label>

      <button className={styles.linkCard}>＋ Привязать карту</button>

      <button className={styles.selectBtn} onClick={onClose}>Выбрать</button>
    </div>
  );
};

export default PaymentModal;
