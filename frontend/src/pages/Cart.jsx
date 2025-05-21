import React, { useState } from 'react';
import styles from '../styles/Cart.module.css';
import { FiTrash2, FiCreditCard } from 'react-icons/fi';
import products from '../data/Products';
import { Modal } from '../components/layout/Modal';
import PaymentModal from '../components/modals/PaymentModal';
import ProfileModal from '../components/modals/ProfileModal';
import AddressModal from '../components/modals/AddressModal';

const Cart = () => {
  const cartItems = products.slice(0, 3);
  const deliveryCost = 130;
  const discount = 0.2;
  const [modalContent, setModalContent] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [phone, setPhone] = useState('');

  const total = cartItems.reduce((acc, item) => acc + item.price, 0);
  const discountAmount = Math.floor(total * discount);
  const finalTotal = total - discountAmount + deliveryCost;

  const openModal = (type) => {
    setModalContent(type);
    setShowModal(true);
  };

  return (
    <div className={styles.cartPage}>
      <div className={styles.cartContainer}>
        <div className={styles.cartItems}>
          {cartItems.map((item) => (
            <div key={item.id} className={styles.cartItem}>
              <img src={item.image} alt={item.name} className={styles.productImage} />
              <div className={styles.itemDetails}>
                <h4>{item.name}</h4>
                <p>Размер: XL</p>
                <p>Цвет: Белый</p>
                <p>{item.price}₽</p>
              </div>
              <div className={styles.quantityControls}>
                <button>-</button>
                <span>1</span>
                <button>+</button>
              </div>
              <button className={styles.deleteButton}><FiTrash2 /></button>
            </div>
          ))}
        </div>

        <div className={styles.summary}>
          <h3>Итог заказа</h3>
          <div className={styles.summaryRow}>
            <span>Товары, {cartItems.length}шт</span>
            <span>{total}₽</span>
          </div>
          <div className={styles.summaryRow}>
            <span>Моя скидка (-20%)</span>
            <span className={styles.discount}>-{discountAmount}₽</span>
          </div>
          <div className={styles.summaryRow}>
            <span>Стоимость доставки</span>
            <span>{deliveryCost}₽</span>
          </div>
          <div className={styles.summaryTotal}>
            <strong>Итого</strong>
            <strong>{finalTotal}₽</strong>
          </div>

          <div className={styles.promoBlock}>
            <input
              type="text"
              placeholder="Добавить промо-код"
              className={styles.promoInput}
            />
            <button className={styles.applyButton}>Применить</button>
          </div>

          <button className={styles.orderButton}>Заказать</button>
        </div>
      </div>

      <div className={styles.deliveryBlockFull}>
        <div className={styles.blockHeader}>
          <h4>Доставка по адресу</h4>
          <button onClick={() => openModal('address')} className={styles.editButton}>✎</button>
        </div>
        <p>Екатеринбург, Новосибирский Бульвар 7 (доставка до двери)</p>
        <p>Время доставки: ежедневно с 09:00 до 21:00</p>
        <p className={styles.eta}>Ожидаемая доставка — сб, послезавтра</p>
      </div>

      <div className={styles.extraBlocks}>
        <div className={styles.paymentBlock}>
          <div className={styles.blockHeader}>
            <h4>Способ оплаты</h4>
            <button onClick={() => openModal('payment')} className={styles.editButton}>✎</button>
          </div>
          <p><FiCreditCard /> РТ Кошелёк: 100 ₽</p>
        </div>

        <div className={styles.profileBlock}>
          <div className={styles.blockHeader}>
            <h4>Мои данные</h4>
            <button onClick={() => openModal('profile')} className={styles.editButton}>✎</button>
          </div>
          {/* <input
            type="tel"
            value={phone}
            onChange={(e) => setPhone(e.target.value)}
            placeholder="+7 (___) ___-__-__"
            className={styles.phoneInput}
          /> */}
          <p>+7 (___) ___-__-__</p>
        </div>
      </div>

      {showModal && (
        <Modal onClose={() => setShowModal(false)}>
          {modalContent === 'payment' && <PaymentModal onClose={() => setShowModal(false)} />}
          {modalContent === 'profile' && <ProfileModal onClose={() => setShowModal(false)} />}
          {modalContent === 'address' && <AddressModal onClose={() => setShowModal(false)} />}
        </Modal>
      )}
    </div>
  );
};

export default Cart;
