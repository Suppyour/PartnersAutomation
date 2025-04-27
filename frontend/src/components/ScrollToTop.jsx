import { useEffect } from "react";
import { useLocation } from "react-router-dom";

const ScrollToTop = () => {
  const { pathname } = useLocation();

  useEffect(() => {
    window.scrollTo({
      top: 0,
      behavior: "auto", // можешь поставить "auto" если не хочешь плавности
    });
  }, [pathname]);

  return null;
};

export default ScrollToTop;
