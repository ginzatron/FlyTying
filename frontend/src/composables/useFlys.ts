import { computed, ref } from "vue";

const flys = ref([] as any);

export function useFlys() {
  const loading = ref(false);
  const filteredFlyList = ref([] as any);
  const foundFly = ref({
    loading: false,
    error: "",
    data: {},
  });
  
  async function filter(searchTerm: string) {
    // not sure why this isn't updating when called from filter
    filteredFlyList.value.push(flys.value.filter((f: any) => f.name.toLowerCase().includes(searchTerm)))
  }

  async function getFlys() {
    flys.value = [];
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

    filter('');
  }

  // wnat to filter from global store fly list
  async function search(searchId: string) {
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
    search,
    filter
  };
}
