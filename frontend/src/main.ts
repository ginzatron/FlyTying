import { createApp } from 'vue'
import { Quasar } from 'quasar'

import '@quasar/extras/material-icons/material-icons.css'
import '@quasar/extras/fontawesome-v5/fontawesome-v5.css'

import 'quasar/src/css/index.sass'

import App from './App.vue'

const myApp = createApp(App)
myApp.use(Quasar, {
    plugins: {}, // import Quasar plugins and add here
})

myApp.mount('#app')
