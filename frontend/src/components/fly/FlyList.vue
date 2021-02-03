<template>
  <div v-for="fly in flys" :key="fly.id">
    <h3>
      <router-link :to="{ name: 'Fly', params: { id: fly.id } }">{{
        fly.pattern.name
      }}</router-link>
    </h3>
  </div>
</template>

<script>
import { ref } from "vue";

export default {
  props: ["list"],
  setup(props) {
    const flys = ref(props.list);

    return {
      flys,
    };
  },
};
</script>

<style>
</style>