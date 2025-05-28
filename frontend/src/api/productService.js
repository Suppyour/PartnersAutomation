const API_BASE_URL = 'https://localhost:7108/api/Product';

export const getProducts = async () => {
    try {
        const response = await fetch(API_BASE_URL);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching products:', error);
        throw error;
    }
};

export const searchProducts = async (name) => {
    try {
        const response = await fetch(`${API_BASE_URL}/search?name=${encodeURIComponent(name)}`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return await response.json();
    } catch (error) {
        console.error('Error searching products:', error);
        throw error;
    }
};

// Другие методы API по аналогии