import axios from 'axios';

const API_URL = 'https://localhost:7108/api/User';

export const registerUser = async (login, email, password) => {
    try {
        const response = await axios.post(`${API_URL}/Register`, {
            Login: login, // с большой буквы, как ожидает бэкенд
            Email: email, // с большой буквы
            Password: password // с большой буквы
        });
        return response.data;
    } catch (error) {
        console.error('Registration error details:', error.response?.data);
        throw error.response?.data?.message || error.message || 'Ошибка регистрации';
    }
};

export const loginUser = async (email, password) => {
    try {
        const response = await axios.post(`${API_URL}/Login`, {
            Email: email, // с большой буквы
            Password: password // с большой буквы
        });

        // Добавим логирование ответа для отладки
        console.log('Login response:', response.data);

        return response.data;
    } catch (error) {
        console.error('Login error details:', error.response?.data);
        throw error.response?.data?.message || error.message || 'Ошибка входа';
    }
};