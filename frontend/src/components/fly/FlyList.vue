<template>
  <div v-for="fly in flys" :key="fly.id">
    <!-- should this loop and output a component where the id is passed as a prop -->
    <h3>
      <router-link :to="{name: 'Fly', params: {id: fly.id}}">{{ fly.name }}</router-link>
      <!-- or should this be a component with the id passed as a prop -->
    </h3>
  </div>
  <router-view></router-view>
</template>

<script>
import { onMounted, ref } from "vue";

export default {
  setup() {
    const flys = ref([]);

    async function getFlys() {
      // should just return objects with name, id from mongo
      const response = await fetch(`https://localhost:44352/api/recipes`, {
        headers: {
          accept: "application/json",
        },
      });
      const data = await response.json();
      flys.value = data;
    }





    onMounted(getFlys);

    return {
      flys,
      getFlys,
    };
  },
};
</script>

<style>
</style>