<template>
  <div class="container">
    <the-header></the-header>
    <div class="content">
      <router-view class="main-content" />
      <the-side-bar class="left-sidebar"></the-side-bar>
    </div>
  </div>
</template>

<script>
import TheHeader from "./components/general/TheHeader.vue";
import TheSideBar from "@/components/general/TheSideBar.vue";

export default {
  components: {
    TheHeader,
    TheSideBar,
  },
};
</script>

<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

.container {
  display: flex;
  min-height: 100vh;
  flex-direction: column;
}

.content {
  display: flex;
  flex: 1;
}

.main-content {
  flex: 1;
}

.left-sidebar {
  flex: 0 0 12em;
  order: -1;
}
</style>
