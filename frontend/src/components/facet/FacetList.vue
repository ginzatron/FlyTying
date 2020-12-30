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
import { onMounted, reactive } from "vue";
import Facet from "@/components/facet/Facet.vue";

export default {
  components: {
    Facet,
  },
  setup() {
    const facets = reactive({
      available: [],
      selected: [],
    });

    async function matchSearch(searchTerm) {
      console.log(`searching for ${searchTerm}`);
      facets.selected.push(searchTerm);
      console.log(facets.selected);
    }

    async function getFacets() {
      const response = await fetch(
        `https://localhost:44352/api/recipes/facet`,
        {
          headers: {
            accept: "application/json",
          },
        }
      );
      let data = await response.json();
      data = JSON.parse(data);

      for (const key in data) {
        const obj = {
          title: key,
          items: data[key],
        };
        for (const key in obj.items) {
          const facet = {
            title: obj.items[key]._id,
            count: obj.items[key].count,
          };
          facets.available.push(facet);
        }
      }
    }

    onMounted(getFacets);

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