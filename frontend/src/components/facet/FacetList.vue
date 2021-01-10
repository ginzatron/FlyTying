<template>
  <section>
    <div v-if="loading">
      <h2>Loading</h2>
    </div>
    <div class="facet-container" v-else-if="!loading && facets.selected.length === 0">
      <facet
        v-for="facet in facets.available"
        :key="facet.title"
        :facet="facet.title"
        @setFacet="updateFacets"
      >
      </facet>
    </div>
      <div v-for="facet in facets.selected" :key="facet.title" @click="removeFacet">
        {{ facet }} is selected
        <!-- going to have remove method on click -->
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
  setup(_,{emit}) {
    const { getFacets, facets, loading } = useFacets();

    async function updateFacets(facet) {
      facets.selected.push(facet);
      facets.available = facets.available.filter(f => f.title !== facet);
      emit('searchFacet',facet);
    }

    async function removeFacet() {
      facets.selected = [];
      facets.available = [];
      emit('resetFacets');
      getFacets();
    }

    onMounted(getFacets());

    return {
      facets,
      loading,
      updateFacets,
      removeFacet
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