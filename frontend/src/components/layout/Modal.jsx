import React from 'react';
import styles from '../../styles/Modal.module.css';

export const Modal = ({ children, onClose }) => {
  return (
    <div className={styles.overlay} onClick={onClose}>
      <div
        className={styles.modal}
        onClick={(e) => e.stopPropagation()}
      >
        <button className={styles.closeButton} onClick={onClose}>
          ✕
        </button>
        <div className={styles.modalContent}>
          {children}
        </div>
      </div>
    </div>
  );
};


