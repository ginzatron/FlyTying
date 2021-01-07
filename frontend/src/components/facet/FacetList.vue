<template>
  <section>
    <div v-if="loading">
      <h2>Loading</h2>
    </div>
    <div class="facet-container" v-else-if="!loading">
      <facet
        v-for="facet in facets.available"
        :key="facet.title"
        :name="facet.title"
        :count="facet.count"
        @matchSearch="matchSearch"
      >
      </facet>
      <div v-for="facet in facets.selected" :key="facet.title">
        {{ facet }}
        <!-- going to have remove method on click -->
      </div>
    </div>
  </section>
</template>

<script>
import { onMounted } from "vue";
import { useFacets } from "@/composables/useFacets";
import Facet from "@/components/facet/Facet.vue";

export default {
  components: {
    Facet,
  },
  setup() {
    const { getFacets, facets, loading } = useFacets();

    async function matchSearch(searchTerm) {
      console.log(`searching for ${searchTerm}`);
      facets.selected.push(searchTerm);
    }

    onMounted(getFacets());

    return {
      facets,
      loading,
      matchSearch,
    };
  },
};
</script>

<style scoped>
.facet-container {
  display: flex;
  flex-direction: column;
}
</style>