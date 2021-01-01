import { ref, reactive, computed } from 'vue';

const facets = reactive({
    available: [] as any,
    selected: [] as any,
  });

export function useFacets(){
    const loading = ref(false);

    async function getFacets() {
        loading.value = true;
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
        loading.value = false;
  
        const facets = [];
        for (const item in data) {
           facets.push(data[item]);
           facets.forEach((f) => {
            console.log(f); 
           })
        }
      }

      return {
          getFacets,
          loading: computed(() => loading.value),
          facets: computed(() => facets)
      }
}