<template>
  <the-header></the-header>
  <fly-list></fly-list>
  <router-view/>
</template>

<script>
import TheHeader from './components/general/TheHeader.vue';
import FlyList from '@/components/fly/FlyList.vue';

export default {
  components: {
    TheHeader,
    FlyList
  }
}
</script>

<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  background-color: #cfd0da;
}
</style>
