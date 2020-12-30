<template>
  <div class="layout">
    <the-header></the-header>
    <the-side-bar></the-side-bar>
    <div class="mainContent">
      <router-view />
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
</style>
