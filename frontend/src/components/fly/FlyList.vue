<template>

  <!-- make a search component to house these two items -->
  <fly-search v-model="nameToSearch"></fly-search>
  <facet-list @searchFacet="matchFacet" @resetFacets="reset"></facet-list>
  <!-- Remove sidebar possibly -->

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
import FacetList from '@/components/facet/FacetList';

export default {
  components: {
    FlySearch,
    FacetList
  },
  setup() {
    const { getFlys, filteredNames, loading, nameToSearch, facetsToSearch } = useFlys();

    async function matchFacet (facet) {
      facetsToSearch.value.push(facet);
    }

    async function reset() {
      facetsToSearch.value = [];
    }

    onMounted(getFlys);

    return {
      loading,
      nameToSearch,
      filteredNames,
      matchFacet,
      reset
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