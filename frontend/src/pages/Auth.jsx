import React from "react";
import { useState } from "react";
import { Link } from "react-router-dom";
import styles from "../styles/Auth.module.css";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";


function Auth() {
  const [form, setForm] = useState({
    email: "",
    username: "",
    password: "",
    confirmPassword: "",
  });

  const [errors, setErrors] = useState({});

  const { login } = useAuth();
  const navigate = useNavigate();


  const validate = () => {
    const newErrors = {};

    if (!form.email) {
      newErrors.email = "Это обязательное поле";
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(form.email)) {
      newErrors.email = "Email введён в неправильном формате";
    }

    if (!form.username.trim()) {
      newErrors.username = "Это обязательное поле";
    }

    if (!form.password) {
      newErrors.password = "Это обязательное поле";
    } else if (form.password.length < 6) {
      newErrors.password = "Пароль слишком короткий. Пароль должен состоять хотя бы из 6 символов";
    }

    if (!form.confirmPassword) {
      newErrors.confirmPassword = "Это обязательное поле";
    } else if (form.confirmPassword !== form.password) {
      newErrors.confirmPassword = "Пароли не совпадают";
    }

    return newErrors;
  };

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
    setErrors({ ...errors, [e.target.name]: "" });
  };

  // const handleSubmit = (e) => {
  //   e.preventDefault();
  //   const validationErrors = validate();
  //   if (Object.keys(validationErrors).length > 0) {
  //     setErrors(validationErrors);
  //   } else {
  //     // TODO: регистрация
  //     console.log("Регистрация отправлена", form);
  //   }
  // };

  const handleSubmit = (e) => {
    e.preventDefault();
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
    } else {
      login();           // ← временно авторизуем
      navigate("/profile"); // ← переход после регистрации
    }
  };
  

  return (
    <div className={styles.registerPage}>
      <div className={styles.formContainer}>
        <h1 className={styles.title}>Новый аккаунт</h1>
        <p className={styles.subtitle}>
          Уже есть аккаунт? <Link to="/login" className={styles.link}>Войти</Link>
        </p>

        <form className={styles.form} onSubmit={handleSubmit}>
          <label className={styles.label}>
            Эл. почта
            <input
              name="email"
              type="email"
              className={`${styles.input} ${errors.email}`}
              value={form.email}
              onChange={handleChange}
            />
            {errors.email && <span className={styles.error}>{errors.email}</span>}
          </label>

          <label className={styles.label}>
            Придумайте логин
            <input
              name="username"
              type="text"
              className={`${styles.input} ${errors.username}`}
              value={form.username}
              onChange={handleChange}
            />
            {errors.username && <span className={styles.error}>{errors.username}</span>}
          </label>

          <label className={styles.label}>
            Придумайте пароль
            <input
              name="password"
              type="password"
              className={`${styles.input} ${errors.password}`}
              value={form.password}
              onChange={handleChange}
            />
            {errors.password && <span className={styles.error}>{errors.password}</span>}
          </label>

          <label className={styles.label}>
            Подтвердите пароль
            <input
              name="confirmPassword"
              type="password"
              className={`${styles.input} ${errors.confirmPassword}`}
              value={form.confirmPassword}
              onChange={handleChange}
            />
            {errors.confirmPassword && <span className={styles.error}>{errors.confirmPassword}</span>}
          </label>

          <button type="submit" className={styles.submitButton}>
            Зарегистрироваться
          </button>
        </form>
      </div>
    </div>
    );
  }
  
  export default Auth;