<template>
  <fly-search @flySearch="search"></fly-search>
  <div v-if="loading">
    <h1>Loading</h1>
  </div>
  <div class="main" v-if="!loading">
    <div v-for="fly in filteredFlyList" :key="fly.id">
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
import { onMounted } from "vue";
import { useFlys } from "@/composables/useFlys";
import FlySearch from './FlySearch.vue';

export default {
  components: {
    FlySearch,
  },
  setup() {
    const { getFlys, loading, filteredFlyList, nameToSearch } = useFlys();

    function search(searchTerm) {
      nameToSearch.value = searchTerm;
    }

    onMounted(getFlys);

    return {
      loading,
      filteredFlyList,
      nameToSearch,
      search
    }
  }
}
</script>

<style scoped>
.main {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-content: center;
}
</style>