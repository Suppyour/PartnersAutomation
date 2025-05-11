import React from "react";
import { useState } from "react";
import styles from "../styles/Login.module.css";
import { Link, useNavigate } from "react-router-dom";
import { ArrowRight } from "lucide-react";
import { useAuth } from "../context/AuthContext";


function Login() {
    const { login } = useAuth();
    const navigate = useNavigate();  

    const [form, setForm] = useState({
        username: "",
        password: "",
        email: "",
      });
    
      const [errors, setErrors] = useState({});
      const [loginError, setLoginError] = useState("");
    
      const validate = () => {
        const newErrors = {};
    
        if (!form.username.trim()) {
          newErrors.username = "Это обязательное поле";
        }
    
        if (!form.password) {
          newErrors.password = "Это обязательное поле";
        }
    
        if (!form.email) {
          newErrors.email = "Это обязательное поле";
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(form.email)) {
          newErrors.email = "Email введён в неправильном формате";
        }
    
        return newErrors;
      };
    
      const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
        setErrors({ ...errors, [e.target.name]: "" });
        setLoginError("");
      };
    
      // const handleSubmit = (e) => {
      //   e.preventDefault();
      //   const validationErrors = validate();
      //   if (Object.keys(validationErrors).length > 0) {
      //     setErrors(validationErrors);
      //     return;
      //   }
    
      //   // Проверка логина и пароля
      //   if (form.username !== "demoUser" || form.password !== "123456") {
      //     setLoginError("Неправильный логин или пароль");
      //     return;
      //   }
    
      //   // Всё хорошо — отправка формы
      //   console.log("Отправка формы", form);
      // };
    
      const handleSubmit = (e) => {
        e.preventDefault();
        const validationErrors = validate();
        if (Object.keys(validationErrors).length > 0) {
          setErrors(validationErrors);
          return;
        }
      
        // Временная проверка (уберу позже)
        if (form.username !== "test" || form.password !== "123456" || form.email !== "test@test.com") {
          setLoginError("Неправильный логин или пароль");
          return;
        }
      
        login();            // авторизуем
        navigate("/profile");  // переход после входа
      };
      

      return (
        <div className={styles.loginPage}>
          <div className={styles.formContainer}>
            <h1 className={styles.title}>Войти</h1>
            <p className={styles.subtitle}>
              У вас еще нет аккаунта?{" "}
              <Link to="/auth" className={styles.link}>
                Зарегистрироваться
              </Link>
            </p>
    
            <form className={styles.form} onSubmit={handleSubmit}>
              <label className={styles.label}>
                Логин
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
                Пароль
                <div className={styles.passwordRow}>
                  <input
                    name="password"
                    type="password"
                    className={`${styles.input} ${errors.password}`}
                    value={form.password}
                    onChange={handleChange}
                  />
                  <Link to="/forgot-password" className={styles.forgotLink}>
                    Забыли пароль?
                  </Link>
                  {errors.password && <span className={styles.error}>{errors.password}</span>}
                </div>
              </label>
    
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

              {loginError && <div className={styles.error}>{loginError}</div>}
    
              <button type="submit" className={styles.submitButton}>
                Продолжить с эл. почтой <ArrowRight size={16} />
              </button>
            </form>
          </div>
        </div>
    );
  }
  
  export default Login;