import axios from "axios"

const instance = axios.create({
  // baseURL: 'http://localhost:65028/',
  baseURL: 'http://localhost:5000/api/',
  // baseURL: 'https://mtest.xbase.web.tr/api/xbase/',
  timeout: 60000,
  headers: {
    'Content-Type': 'application/json'
  },
});

instance.interceptors.request.use(function (config) {
  return config;
}, function (error) {
  return Promise.reject(error);
});

instance.interceptors.response.use((response) => response, (error) => {
  this.$store.commit('showAlert()');
  return Promise.reject(error);
});

export default instance;