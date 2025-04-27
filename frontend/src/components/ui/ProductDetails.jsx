import React, { useState } from "react";
import styles from "../../styles/ProductDetails.module.css";
import products from "../../data/Products.jsx"; // Импортируем описание

const ProductDetails = () => {
  const [activeTab, setActiveTab] = useState("about");
//   const [input, setInput] = useState("");
  const [questions, setQuestions] = useState([
    {
      id: 1,
      name: "Эльдар",
      date: "04 апреля",
      question: "Здравствуйте! Подскажите, сильно ли ткань просвечивает на свету? Можно ли носить футболку без майки под ней?",
      answer: "Здравствуйте! Ткань средней плотности, почти не просвечивает. Можно спокойно носить без майки — выглядит аккуратно и комфортно.",
    },
    {
      id: 2,
      name: "Мадина",
      date: "04 апреля",
      question: "Здравствуйте! Подскажите, сильно ли ткань просвечивает на свету? Можно ли носить футболку без майки под ней?",
      answer: "Здравствуйте! Ткань средней плотности, почти не просвечивает. Можно спокойно носить без майки — выглядит аккуратно и комфортно.",
    },
  ]);
  const [newQuestion, setNewQuestion] = useState("");

  const product = products[0]; // Временно берём первый продукт

  const handleAddQuestion = () => {
    if (newQuestion.trim()) {
      const newEntry = {
        id: Date.now(),
        name: "Пользователь",
        date: new Date().toLocaleDateString("ru-RU", { day: '2-digit', month: 'long' }),
        question: newQuestion,
        answer: null,
      };
      setQuestions([newEntry, ...questions]);
      setNewQuestion("");
    }
  };

  return (
    <div className={styles.container}>
      {/* Навигация */}
      <div className={styles.nav}>
        <button onClick={() => setActiveTab("about")} className={activeTab === "about" ? styles.active : ""}>О товаре</button>
        {/* <button onClick={() => setActiveTab("reviews")} className={activeTab === "reviews" ? styles.active : ""}>Отзывы</button> */}
        <button onClick={() => setActiveTab("questions")} className={activeTab === "questions" ? styles.active : ""}>Вопросы</button>
      </div>

      {/* Контент */}
      <div className={styles.content}>
        {activeTab === "about" && (
          <div className={styles.section}>
            <h2>Описание товара</h2>
            <p>{product.description.about}</p>

            <h2>Состояние</h2>
            <div>
              {product.description.condition.map((item, index) => (
                <p key={index}>{item}</p>
              ))}
            </div>

            <h2>Технические характеристики</h2>
            <ul>
              {product.description.technical.map((item, index) => (
                <li key={index}>{item}</li>
              ))}
            </ul>

            <h2>Дефекты и особенности</h2>
            <ul>
              {product.description.defects.map((item, index) => (
                <li key={index}>{item}</li>
              ))}
            </ul>
          </div>
        )}

        {activeTab === "reviews" && (
          <div className={styles.section}>
            <h2>Отзывы</h2>
            <p>Пока нет отзывов.</p>
          </div>
        )}

        {activeTab === "questions" && (
          <div className={styles.section}>
            <h2 className={styles.questionsTitle}>Вопросы <span>({questions.length})</span></h2>

            <div className={styles.askBlock}>
              <textarea
                className={styles.textarea}
                placeholder="Задайте вопрос о товаре"
                value={newQuestion}
                onChange={(e) => setNewQuestion(e.target.value)}
                maxLength={1000}
              />
              <div className={styles.buttons}>
                <button className={styles.submitBtn} onClick={handleAddQuestion}>Задать вопрос</button>
                <button className={styles.cancelBtn} onClick={() => setNewQuestion("")}>Отменить</button>
              </div>
              {/* <div className={styles.charCounter}>
                Введено символов {input.length} / 1000
              </div> */}
            </div>

            <div className={styles.questionsList}>
              {questions.map((q) => (
                <div key={q.id} className={styles.questionCard}>
                  <div className={styles.userInfo}>
                    <strong>{q.name}</strong>
                    <span>{q.date}</span>
                  </div>
                  <p className={styles.userQuestion}>{q.question}</p>
                  {q.answer && (
                    <div className={styles.answerBlock}>
                      <div className={styles.answerTitle}>Ответ продавца</div>
                      <p>{q.answer}</p>
                    </div>
                  )}
                </div>
              ))}
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default ProductDetails;
