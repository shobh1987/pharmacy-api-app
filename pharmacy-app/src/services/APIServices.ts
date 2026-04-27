import axios from "axios";

const API_BASE_URL = import.meta.env.VITE_APP_API_URL;
console.log("API Base URL:", API_BASE_URL);
const axisosInstance = axios.create({
    baseURL: `${API_BASE_URL}api/`,
    headers: {
        "Content-Type": "application/json",
    },
});

// axisosInstance.interceptors.request.use(
//     (config) => {
//         const token = localStorage.getItem("token");
//         if (token) {
//             config.headers["Authorization"] = `Bearer ${token}`;
//         }
//         return config;
//     }
//     , (error) => {
//         return Promise.reject(error);
//     }
// );

// axisosInstance.interceptors.response.use(
//     (response) => {
//         return response;
//     }
//     , (error) => {
//         return Promise.reject(error);
//     }
// );

export default axisosInstance;