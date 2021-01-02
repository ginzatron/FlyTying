import { computed, ref, watch } from "vue";

const flys = ref([] as any);

export function useFlys() {
  const loading = ref(false);
  const nameToSearch = ref('');
  const foundFly = ref({
    loading: false,
    error: "",
    data: {},
  });

  const filteredFlyList = computed(() => {
    if (nameToSearch.value)
      return flys.value.filter((f: any) => f.name.toLowerCase().includes(nameToSearch.value));
    
    return flys.value;
  })

  watch(nameToSearch, (newVal) => {
    nameToSearch.value = newVal;
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
      flys.value.push(item);
    }
  }

  // wnat to filter from global store fly list
  async function searchForFly(searchId: string) {
    loading.value = true;
    const response = await fetch(
      `https://localhost:44352/api/recipes/${searchId}`,
      {
        headers: {
          accept: "application/json",
        },
      }
    );
    const data = await response.json();
    loading.value = false;
    foundFly.value.data = data;
  }

  return {
    loading: computed(() => loading.value),
    foundFly: computed(() => foundFly.value),
    filteredFlyList,
    getFlys,
    searchForFly,
    nameToSearch
  };
}
