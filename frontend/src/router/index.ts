import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";

import NotFound from "../views/NotFound.vue";
import Home from "../views/Home.vue";
import FlyList from "@/components/fly/FlyList.vue";
import FlyDetail from "@/components/fly/FlyDetail.vue";

const routes: Array<RouteRecordRaw> = [
  { 
    path: "/", 
    component: Home 
  },
  { 
    path: "/flys", 
    component: FlyList,
  },
  { 
    path: '/flys/:id', 
    component: FlyDetail,
    props: true 
  },
  { 
    path: "/:notFound(.*)", 
    component: NotFound 
  },
];

const router = createRouter({
  // history: createWebHistory(process.env.BASE_URL),
  history: createWebHistory(),
  routes,
});

export default router;
