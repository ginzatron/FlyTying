<template>
  <section>
    <facet
      v-for="facet in facets.data"
      :key="facet.title"
      :name="facet.title"
      :count="facet.count">
    </facet>
  </section>
</template>

<script>
import { onMounted, reactive } from "vue";
import Facet from "@/components/facet/Facet.vue";

export default {
  components: { Facet },
  setup() {
    const facets = reactive({
      data: [{title:'facet1',count:2},{title:'facet2', count:4},{title:'facet3', count:1}],
    });

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
          count: data[key],
        };
        facets.data.push(obj);
      }
    }

    //onMounted(getFacets);

    return {
      getFacets,
      facets,
    };
  },
};
</script>

<style>
</style>