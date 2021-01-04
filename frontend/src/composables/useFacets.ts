import { ref, reactive, computed } from "vue";

const facets = reactive({
  available: [] as any,
  selected: [] as any,
});

export function useFacets() {
  const loading = ref(false);

  async function getFacets() {
    loading.value = true;
    const response = await fetch(`https://localhost:44352/api/recipes/facet`, {
      headers: {
        accept: "application/json",
      },
    });
    let data = await response.json();
    data = JSON.parse(data);
    loading.value = false;

    const facetlist = [];
    for (const item in data) {
      facetlist.push(...data[item]);
    }

    facetlist.forEach((facet) => {
      facets.available.push({
        title: facet._id,
        count: facet.count,
      });
    });
  }

  return {
    getFacets,
    loading: computed(() => loading.value),
    facets
  };
}