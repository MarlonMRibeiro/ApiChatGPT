import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config';
//theme
import "primevue/resources/themes/lara-light-indigo/theme.css";     
    
//core
import "primevue/resources/primevue.min.css";

import '@fortawesome/fontawesome-free/css/all.css'


const app = createApp(App);
app.use(PrimeVue).mount('#app');