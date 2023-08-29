import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config';
import axios from 'axios'

//theme
import "primevue/resources/themes/lara-light-indigo/theme.css";     

//core
import "primevue/resources/primevue.min.css";

import '@fortawesome/fontawesome-free/css/all.css'

const app = createApp(App);

app.use(PrimeVue);
app.config.globalProperties.$http = axios;
app.mount('#app');