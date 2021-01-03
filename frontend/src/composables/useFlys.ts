import { computed, ref, reactive } from "vue";

const flys = ref([] as any);

export function useFlys() {
  const loading = ref(false);
  const nameToSearch = ref('');
  const foundFly = reactive({
    loading: false,
    error: "",
    data: {},
  });

  const filteredFlyList = computed(() => {
    if (nameToSearch.value)
      return flys.value.filter((f: any) => f.name.toLowerCase().includes(nameToSearch.value));
    
    return flys.value;
  })

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
  }

  async function searchForFly(searchId: string) {
    foundFly.loading = true;
    const response = await fetch(
      `https://localhost:44352/api/recipes/${searchId}`,
      {
        headers: {
          accept: "application/json",
        },
      }
    );
    const data = await response.json();
    foundFly.loading = false;
    foundFly.data = data;
  }

  // async function searchForFly(searchId: string) {
  //   foundFly.value.data = flys.value.find((f: any) => f.id === searchId);
  // }

  return {
    loading: computed(() => loading.value),
    foundFly: computed(() => foundFly),
    filteredFlyList,
    getFlys,
    searchForFly,
    nameToSearch
  };
}
