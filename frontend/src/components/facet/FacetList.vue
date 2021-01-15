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
        v-for="facet in facets.list"
        :key="facet.title"
        :facet="facet.title"
        :selected="facet.isSelected"
        @facetSelected="setSelectedFacet"
      >
      </facet>
    </div>
  </section>
</template>

<script>
import { onMounted } from "vue";
import { useFacets } from "@/composables/useFacets";
import {ref, reactive, watch} from 'vue';
import Facet from "@/components/facet/Facet.vue";

export default {
  components: {
    Facet,
  },
  setup() {
    const loading = ref(false);
    const facets = reactive({
      list: []
    });
    const selectedFacet = ref('');

    const { getFacets} = useFacets();

    async function createFacets(){
        loading.value = true;
        const facetList = await getFacets();
        loading.value = false;

        console.log(facetList);

        facetList.forEach((facet) => {
          const newFacet = {
            title: facet._id,
            count: facet.count,
            isSelected: false
          }
          facets.list.push(newFacet);
        })
    }
    
    async function setSelectedFacet(facet) {
      if (facet === selectedFacet.value)
        selectedFacet.value = '';
      else
        selectedFacet.value = facet;
    }

    watch(selectedFacet, (newValue) => {
      console.log(`here with ${newValue}`);
      facets.list = facets.list.map((f) =>  {
        if (f.title !== newValue)
          f.isSelected = false;
         else 
          f.isSelected = true;
        return f;
      })
    })

    // why is facets.list not dictating the class on the facet component?

      //emit("searchFacet", facet);

    onMounted(createFacets());

    return {
      facets,
      setSelectedFacet,
      loading
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