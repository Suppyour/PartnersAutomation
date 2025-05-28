import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import styles from "../styles/Auth.module.css";
import { useAuth } from "../context/AuthContext";
import { registerUser, loginUser } from "../api/authService";

function Auth() {
  const [form, setForm] = useState({
    email: "",
    login: "", // изменили username на login
    password: "",
    confirmPassword: "",
  });

  const [errors, setErrors] = useState({});
  const [isSubmitting, setIsSubmitting] = useState(false);
  const { login } = useAuth();
  const navigate = useNavigate();

  const validate = () => {
    const newErrors = {};

    if (!form.email.trim()) {
      newErrors.email = "Это обязательное поле";
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(form.email)) {
      newErrors.email = "Email введён в неправильном формате";
    }

    if (!form.login.trim()) { // изменили username на login
      newErrors.login = "Это обязательное поле"; // изменили username на login
    } else if (form.login.length < 3) { // изменили username на login
      newErrors.login = "Логин должен содержать минимум 3 символа"; // изменили username на login
    }

    if (!form.password) {
      newErrors.password = "Это обязательное поле";
    } else if (form.password.length < 6) {
      newErrors.password = "Пароль должен содержать минимум 6 символов";
    }

    if (!form.confirmPassword) {
      newErrors.confirmPassword = "Это обязательное поле";
    } else if (form.confirmPassword !== form.password) {
      newErrors.confirmPassword = "Пароли не совпадают";
    }

    return newErrors;
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm(prev => ({ ...prev, [name]: value }));

    if (errors[name]) {
      setErrors(prev => ({ ...prev, [name]: "" }));
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    setIsSubmitting(true);
    setErrors(prev => ({ ...prev, api: "" }));

    try {
      // 1. Регистрация
      await registerUser(form.login, form.email, form.password);

      // 2. Автоматический вход
      const loginData = await loginUser(form.email, form.password);

      // 3. Проверяем структуру ответа
      if (!loginData.token) {
        throw new Error('Токен не получен в ответе от сервера');
      }

      // 4. Сохраняем данные в контекст
      login(loginData.token, {
        email: form.email,
        login: form.login
      });

      // 5. Перенаправляем
      navigate("/profile");

    } catch (error) {
      console.error("Full error:", error);
      setErrors(prev => ({
        ...prev,
        api: error.message || "Ошибка регистрации или входа"
      }));
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
      <div className={styles.registerPage}>
        <div className={styles.formContainer}>
          <h1 className={styles.title}>Новый аккаунт</h1>
          <p className={styles.subtitle}>
            Уже есть аккаунт? <Link to="/login" className={styles.link}>Войти</Link>
          </p>

          {errors.api && <div className={styles.apiError}>{errors.api}</div>}

          <form className={styles.form} onSubmit={handleSubmit} noValidate>
            <div className={styles.formGroup}>
              <label className={styles.label}>
                Эл. почта
                <input
                    name="email"
                    type="email"
                    className={`${styles.input} ${errors.email ? styles.inputError : ""}`}
                    value={form.email}
                    onChange={handleChange}
                    disabled={isSubmitting}
                />
                {errors.email && <span className={styles.error}>{errors.email}</span>}
              </label>
            </div>

            <div className={styles.formGroup}>
              <label className={styles.label}>
                Придумайте логин
                <input
                    name="login" // изменили username на login
                    type="text"
                    className={`${styles.input} ${errors.login ? styles.inputError : ""}`} // изменили username на login
                    value={form.login} // изменили username на login
                    onChange={handleChange}
                    disabled={isSubmitting}
                />
                {errors.login && <span className={styles.error}>{errors.login}</span>} {/* изменили username на login */}
              </label>
            </div>

            <div className={styles.formGroup}>
              <label className={styles.label}>
                Придумайте пароль
                <input
                    name="password"
                    type="password"
                    className={`${styles.input} ${errors.password ? styles.inputError : ""}`}
                    value={form.password}
                    onChange={handleChange}
                    disabled={isSubmitting}
                />
                {errors.password && <span className={styles.error}>{errors.password}</span>}
              </label>
            </div>

            <div className={styles.formGroup}>
              <label className={styles.label}>
                Подтвердите пароль
                <input
                    name="confirmPassword"
                    type="password"
                    className={`${styles.input} ${errors.confirmPassword ? styles.inputError : ""}`}
                    value={form.confirmPassword}
                    onChange={handleChange}
                    disabled={isSubmitting}
                />
                {errors.confirmPassword && <span className={styles.error}>{errors.confirmPassword}</span>}
              </label>
            </div>

            <button
                type="submit"
                className={styles.submitButton}
                disabled={isSubmitting}
            >
              {isSubmitting ? "Регистрация..." : "Зарегистрироваться"}
            </button>
          </form>
        </div>
      </div>
  );
}

export default Auth;