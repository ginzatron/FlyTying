<template>
  <div v-if="loading">
    <h1>Loading</h1>
  </div>
  <div class="main" v-if="!loading">
    <div v-for="fly in flys" :key="fly.id">
      <!-- should this loop and output a component where the id is passed as a prop -->
      <h3>
        <router-link :to="{ name: 'Fly', params: { id: fly.id } }">{{
          fly.name
        }}</router-link>
        <!-- or should this be a component with the id passed as a prop -->
      </h3>
    </div>
  </div>
</template>

<script >
import { onMounted, ref } from "vue";
import { useFlys } from '@/composables/useFlys';

export default {
  setup() {
    const {flys, getFlys, loading} = useFlys();

    onMounted(getFlys);

    return {
      flys,
      loading
    };
  },
};
</script>

<style scoped>
.main {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-content: center;
}
</style>