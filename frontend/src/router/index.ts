import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";

import NotFound from "../views/NotFound.vue";
import Home from "../views/Home.vue";
import FlyList from "@/components/fly/FlyList.vue";
import FlyDetail from "@/components/fly/FlyDetail.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/flys",
    name: "Flys",
    component: FlyList,
  },
  {
    path: "/flys/:id",
    name: "Fly",
    component: FlyDetail,
    props: true,
  },
  {
    path: "/:notFound(.*)",
    name: "NofFound",
    component: NotFound,
  },
];

const router = createRouter({
  // history: createWebHistory(process.env.BASE_URL),
  history: createWebHistory(),
  routes,
});

export default router;
