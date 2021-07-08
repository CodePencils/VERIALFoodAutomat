import Vue from 'vue'
import App from './App.vue'
import axios from "./axios";
import { BootstrapVue, BootstrapVueIcons } from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
Vue.use(BootstrapVueIcons)
Vue.use(BootstrapVue)
Vue.config.productionTip = false

new Vue({
  axios,
  render: h => h(App),
}).$mount('#app')
