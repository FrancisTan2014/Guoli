import Vue from 'vue'
import router from './router'
import ElementUI from 'element-ui'
import App from './App.vue'
import VueMoment from 'vue-moment'

import 'element-ui/lib/theme-default/index.css'
import 'font-awesome/css/font-awesome.min.css'
import 'nprogress/nprogress.css'

import './utils/messageExt'

Vue.use(ElementUI)
Vue.use(VueMoment)

new Vue({
  el: '#app',
  router,
  template: '<App />',
  components: { App }
})
