<template>
  <button @click="removeSelectedFacets">Reset Search Facets</button>
  <div class="search-Setup" v-if="!loading">
    <div class="available-facets">
      <h3>AvailableFacets</h3>
      <!-- Going to want to do Facet Group component that has Facet components in it -->
      <facet
        v-for="facet in availableFacets"
        :key="facet.title"
        :title="facet.title"
        :count="facet.count"
        :group="facet.group"
        @facetSelected="flipSelected"
      >
        {{ facet.title }} ({{ facet.count }})
      </facet>
    </div>
    <div class="fly">
      <h3>Recipes</h3>
      <div v-for="fly in flys" :key="fly.id">
        <h3>
          <router-link :to="{ name: 'Fly', params: { id: fly.id } }">{{
            fly.pattern.name
          }}</router-link>
        </h3>
      </div>
    </div>
    <div class="selected-Facets">
      <h3>SelectedFacets</h3>
      <facet
        v-for="facet in selectedFacets"
        :key="facet.title"
        :title="facet.title"
        :group="facet.group"
        @facetSelected="flipSelected"
      >
        {{ facet.title }} ({{ facet.count }})
      </facet>
    </div>
  </div>
  <div v-else>LOADING</div>
</template>

<script>
import { ref, computed, onMounted } from "vue";
import Facet from "@/components/facet/Facet.vue";

export default {
  components: {
    Facet,
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
    //Think about making selectedFacets global

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