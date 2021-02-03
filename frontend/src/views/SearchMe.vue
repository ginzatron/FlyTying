<template>
  <button @click="removeSelectedFacets">Reset Search Facets</button>
  <div class="search-Setup" v-if="!loading">
    <div>
      <h3>Available</h3>
      <facet-group
        :facets="availableFacets"
        @facetSelected="flipSelected"
      ></facet-group>
    </div>
    <div>
      <h3>Flys</h3>
      <fly-list :list="flys"></fly-list>
    </div>
    <div>
      <h3>Selected</h3>
      <facet-group
        :facets="selectedFacets"
        @facetSelected="flipSelected"
      ></facet-group>
    </div>
  </div>
  <div v-else>LOADING</div>
</template>

<script>
import { ref, computed, onMounted } from "vue";
import FacetGroup from "@/components/facet/FacetGroup.vue";
import FlyList from "@/components/fly/FlyList.vue";

export default {
  components: {
    FacetGroup,
    FlyList,
  },
  setup() {
    const loading = ref(false);
    const flys = ref([]);
    const facets = ref([]);
    const availableFacets = computed(() => {
      return facets.value.filter((facet) => !facet.selected);
    });
    const selectedFacets = computed(() => {
      return facets.value.filter((facet) => facet.selected);
    });

    async function getFacets() {
      loading.value = true;
      const response = await fetch(
        `https://localhost:44352/api/recipes/facet`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            accept: "application/json",
          },
          body: JSON.stringify(selectedFacets.value),
        }
      );
      const data = await response.json();
      loading.value = false;

      flys.value = data.recipes;
      facets.value = data.facets;
    }

    onMounted(getFacets());

    async function flipSelected({ title, group }) {
      const facet = facets.value.find((x) => {
        return x.title === title && x.group === group;
      });
      facet.selected = !facet.selected;
      await getFacets();
    }

    async function removeSelectedFacets() {
      facets.value.forEach((facet) => {
        facet.selected = false;
      });
      await getFacets();
    }

    return {
      getFacets,
      availableFacets,
      selectedFacets,
      flys,
      flipSelected,
      loading,
      removeSelectedFacets,
    };
  },
};
</script>

<style scoped>
.search-Setup {
  display: flex;
}
</style>