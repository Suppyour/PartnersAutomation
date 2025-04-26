import axios from 'axios';

const API_URL = process.env.REACT_APP_API_URL || 'http://localhost:8000';

export const api = axios.create({
  baseURL: API_URL,
});

// Пример запроса
export const getUsers = async () => {
  const response = await api.get('/users');
  return response.data;
};