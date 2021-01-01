<template>
  <section>
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
  </section>
</template>

<script>
import { onMounted } from "vue";
import { useFacets } from '@/composables/useFacets';
import Facet from "@/components/facet/Facet.vue";

export default {
  components: {
    Facet,
  },
  setup() {
    const {getFacets, facets} = useFacets();

    async function matchSearch(searchTerm) {
      console.log(`searching for ${searchTerm}`);
      facets.selected.push(searchTerm);
    }

    onMounted(getFacets());

    return {
      getFacets,
      facets,
      matchSearch,
    };
  },
};
</script>

<style>
</style>