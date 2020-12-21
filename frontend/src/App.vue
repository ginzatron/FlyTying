<template>
  <the-header></the-header>
  <router-view/>
</template>

<script>
import TheHeader from './components/general/TheHeader.vue';

export default {
  components: {
    TheHeader,
  }
}
</script>

<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
</style>
