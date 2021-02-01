<template>
  <button @click="getFacets">Click me</button>
  <div class="search-Setup">
    <div class="available-facets">
      <h3>AvailableFacets</h3>
      <div
        v-for="facet in availableFacets"
        :key="facet.title"
        @click="flipSelected(facet)"
      >
        {{ facet.title }} ({{ facet.count }})
      </div>
    </div>
    <div class="recipes">
      <h3>Recipes</h3>
      <div v-for="recipe in recipes" :key="recipe.id">
        {{ recipe.pattern.name }}
      </div>
    </div>
    <div class="selected-Facets">
        <h3>SelectedFacets</h3>
        <div
        v-for="facet in selectedFacets"
        :key="facet.title"
        @click="flipSelected(facet)"
      >
        {{ facet.title }} ({{ facet.count }})
      </div>
    </div>
  </div>
</template>

<script>
import { ref, computed } from "vue";

export default {
  setup() {
    const recipes = ref([]);
    const facets = ref([]);
    const availableFacets = computed(() => {
      return facets.value.filter((facet) => !facet.selected);
    });
    const selectedFacets = computed(() => {
      return facets.value.filter((facet) => facet.selected);
    });

    async function getFacets() {
        //TODO: add timeout to keep adding facets, once the request is sent you need ti disable adding facets
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
    
      recipes.value = data.recipes;
      facets.value = data.facets;
    }

    async function flipSelected(facet) {
      facet.selected = !facet.selected;
      await getFacets();
    }

    return {
      getFacets,
      availableFacets,
      selectedFacets,
      recipes,
      flipSelected,
    };
  },
};
</script>

<style scoped>
.search-Setup {
  display: flex;
}
</style>