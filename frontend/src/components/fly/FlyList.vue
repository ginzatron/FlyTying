<template>
  <button @click="getFlys">GetFlys</button>
  <div v-for="fly in flys" :key="fly.id">
    <h3>
      <router-link :to="buildRoute(fly.id)">{{ fly.name }}</router-link>
    </h3>
  </div>
</template>

<script>
import { ref } from "vue";
import { useRoute } from "vue-router";

export default {
  setup() {
    const flys = ref([]);
    const route = useRoute();

    async function getFlys() {
      // const route = useRoute();
      const response = await fetch(`https://localhost:44352/api/recipes`, {
        headers: {
          accept: "application/json",
        },
      });
      const data = await response.json();

      flys.value = data;
    }

    function buildRoute(id) {
      return `${route.path}/${id}`;
    }

    return {
      flys,
      getFlys,
      buildRoute,
    };
  },
};
</script>

<style>
</style>