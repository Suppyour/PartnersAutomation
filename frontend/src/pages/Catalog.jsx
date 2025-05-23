import React, { useState, useEffect } from "react";
import styles from "../styles/Catalog.module.css";
import ProductCard from "../components/layout/ProductCard";
import Filters from "../components/ui/Filters";
import Breadcrumbs from "../components/ui/Breadcrumbs";
import { getProducts, searchProducts } from "../api/productService.js";

function Catalog() {
    const [showFilters, setShowFilters] = useState(false);
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const data = await getProducts();
                setProducts(data);
                setLoading(false);
            } catch (err) {
                setError(err.message);
                setLoading(false);
            }
        };

        fetchProducts();
    }, []);

    const handleSearch = async (searchTerm) => {
        try {
            setLoading(true);
            const data = await searchProducts(searchTerm);
            setProducts(data);
            setLoading(false);
        } catch (err) {
            setError(err.message);
            setLoading(false);
        }
    };

    if (loading) {
        return <div className={styles.catalogPage}>Loading...</div>;
    }

    if (error) {
        return <div className={styles.catalogPage}>Error: {error}</div>;
    }

    return (
        <div className={styles.catalogPage}>
            <Breadcrumbs />

            <div className={styles.topRow}>
                <button
                    className={styles.filterButton}
                    onClick={() => setShowFilters(!showFilters)}
                >
                    Фильтры
                </button>
                <div className={styles.productCount}>
                    Показано 1–{products.length} из {products.length} товаров
                </div>
                <div className={styles.sort}>
                    Сортировать по: <span>рейтингу</span>
                </div>
            </div>

            <div className={styles.mainContent}>
                {showFilters && (
                    <div className={styles.sidebar}>
                        <Filters onSearch={handleSearch} />
                    </div>
                )}

                <div className={styles.productsGrid}>
                    {products.map((product) => (
                        <ProductCard key={product.id} product={product} />
                    ))}
                </div>
            </div>
        </div>
    );
}

export default Catalog;