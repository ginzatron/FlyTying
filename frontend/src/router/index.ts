import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'

import NotFound from '../views/NotFound.vue';
import Home from '../views/Home.vue';

const routes: Array<RouteRecordRaw> = [
  { path: '/', component: Home},
  { path: '/:notFound(.*)', component: NotFound}
]

const router = createRouter({
  // history: createWebHistory(process.env.BASE_URL),
  history: createWebHistory(),
  routes
})

export default router
