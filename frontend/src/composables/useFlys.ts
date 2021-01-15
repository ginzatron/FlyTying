import { computed, ref, reactive, watch } from "vue";

export function useFlys() {
  const flyNames = ref([] as any);
  const loading = ref(false);
  const nameToSearch = ref('');
  const facetsToSearch = ref([] as any);
  const fly = reactive({
    loading: false,
    error: "",
    data: {},
  });

  const filteredNames = computed(() => {
    if (nameToSearch.value)
      return flyNames.value.filter((f: any) => f.name.toLowerCase().includes(nameToSearch.value));
    
    return flyNames.value;
  })

  async function getFlys() {
    loading.value = true;
    const response = await fetch(`https://localhost:44352/api/recipes`, {
      headers: {
        accept: "application/json",
      },
    });
    const data = await response.json();
    loading.value = false;

    for (const item of data) {
      flyNames.value.push({id: item.id,name: item.name});
    }
  }

  async function getFly(searchId: string) {
    fly.loading = true;
    const response = await fetch(
      `https://localhost:44352/api/recipes/${searchId}`,
      {
        headers: {
          accept: "application/json",
        },
      }
    );
    const data = await response.json();
    fly.loading = false;
    fly.data = data;
  }
  
  async function searchWithFacets(value: any) {
    const response = await fetch(`https://localhost:44352/api/recipes/facet/match/?facet=${value}`, {
      headers: {
        accept: "application/json",
      },
    });
    const data = await response.json();
    console.log(data);
  }
  
  // why does this need to be .value
  watch(facetsToSearch.value, (value) => {
    console.log('inwatcher');
    searchWithFacets(value);
  })

  return {
    loading: computed(() => loading.value),
    fly: computed(() => fly),
    getFlys,
    filteredNames,
    getFly,
    nameToSearch,
    facetsToSearch
  };
}
