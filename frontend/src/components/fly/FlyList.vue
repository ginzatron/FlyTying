<template>
  <fly-search v-model="nameToSearch"></fly-search>
  <div v-if="loading">
    <h1>Loading</h1>
  </div>
  <div class="main" v-if="!loading">
    <div v-for="name in filteredNames" :key="name.id">
      <h3>
        <router-link :to="{ name: 'Fly', params: { id: name.id } }">{{
          name.name
        }}</router-link>
      </h3>
    </div>
  </div>
</template>

<script >
import { onMounted } from "vue";
import { useFlys } from "@/composables/useFlys";
import FlySearch from '@/components/fly/FlySearch.vue';

export default {
  components: {
    FlySearch,
  },
  setup() {
    const { populateAutoCompleteNames, filteredNames, loading, nameToSearch } = useFlys();

    onMounted(populateAutoCompleteNames);

    return {
      loading,
      nameToSearch,
      filteredNames
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