<template>
  <section>
    <div v-if="loading">
      <h2>Loading</h2>
    </div>
    <div
      class="facet-container"
      v-else-if="!loading"
    >
      <facet
        v-for="facet in selectableList"
        :key="facet.title"
        :facet="facet.title"
        v-model="facet.isSelected"
        @update="setSelectedFacet"
      >
      </facet>
    </div>
  </section>
</template>

<script>
import { onMounted } from "vue";
import { useFacets } from "@/composables/useFacets";
import {ref, watch} from 'vue';
import Facet from "@/components/facet/Facet.vue";

export default {
  components: {
    Facet,
  },
  setup(_,{emit}) {
    const loading = ref(false);
    const facets = [];
    const selectedFacet = ref('');
    const selectableList = ref([]);

    const { getFacets} = useFacets();

    async function setSelectedFacet(facet) {
      if (facet.value === selectedFacet.value.value)
        selectedFacet.value = '';
      else
        selectedFacet.value = facet;
    }
    
    watch(selectedFacet, (newValue) => {
      selectableList.value = [];
      selectableList.value = facets.map((f) =>  {
        if (f.title !== newValue)
          f.isSelected = false;
        else 
          f.isSelected = true;
        return f;
      });
      emit("searchFacet", selectedFacet.value);
    })

    async function createFacets(){
      loading.value = true;
        const facetList = await getFacets();
        loading.value = false;

        facetList.forEach((facet) => {
          const newFacet = {
            title: facet._id,
            count: facet.count,
            isSelected: false
          }
          facets.push(newFacet);
        })
        selectableList.value = facets;
    }

    onMounted(createFacets());

    return {
      setSelectedFacet,
      loading,
      selectableList
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