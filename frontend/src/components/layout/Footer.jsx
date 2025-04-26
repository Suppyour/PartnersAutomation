import React from "react";
import styles from "../../styles/Footer.module.css";
import { FaEnvelope, FaInstagram, FaGithub } from "react-icons/fa";

function Footer() {
  return (
    <footer className={styles.footer}>
      <div className={styles.subscribeBlock}>
        <div className={styles.subscribeContent}>
          <h2>БУДЬТЕ В КУРСЕ НАШИХ<br />ПОСЛЕДНИХ ПРЕДЛОЖЕНИЙ</h2>
          <div className={styles.subscribeForm}>
            <div className={styles.inputWrapper}>
              <FaEnvelope className={styles.icon} />
              <input type="email" placeholder="Введите свой адрес электронной почты" />
            </div>
            <button>Подпишитесь на рассылку новостей</button>
          </div>
        </div>
      </div>

      <div className={styles.bottomFooter}>
        <div className={styles.brandInfo}>
          <h3>Patience</h3>
          <p>
            У нас есть одежда, которая соответствует вашему стилю и которой вы гордитесь. Как для женщин, так и для мужчин и детей.
          </p>
        </div>

        <div className={styles.icons}>
          <a href="#"><FaInstagram /></a>
          <a href="#"><FaGithub /></a>
        </div>
        <hr className={styles.divider} />        
      </div>
    </footer>
  );
}

export default Footer;
