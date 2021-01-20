import { computed, ref, reactive } from "vue";

export function useFlys() {
  const flys = ref([] as any);
  const loading = ref(false);
  const nameToSearch = ref('');
  const fly = reactive({
    loading: false,
    error: "",
    data: {},
  });

  const filteredNames = computed(() => {
    if (nameToSearch.value)
      return flys.value.filter((f: any) => f.name.toLowerCase().includes(nameToSearch.value));
    
    return flys.value;
  })

  async function getFlys(facet = "") {
    flys.value = [];
    loading.value = true;
    const response = await fetch(`https://localhost:44352/api/recipes?facet=${facet}`, {
      headers: {
        accept: "application/json",
      },
    });
    const data = await response.json();
    loading.value = false;
    flys.value = data;
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

  return {
    loading: computed(() => loading.value),
    fly: computed(() => fly),
    getFlys,
    filteredNames,
    getFly,
    nameToSearch,
  };
}
