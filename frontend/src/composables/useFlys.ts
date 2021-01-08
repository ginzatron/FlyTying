import { computed, ref, reactive } from "vue";

export function useFlys() {
  const autoCompleteNames = ref([] as any);
  const loading = ref(false);
  const nameToSearch = ref('');
  const fly = reactive({
    loading: false,
    error: "",
    data: {},
  });

  const filteredNames = computed(() => {
    if (nameToSearch.value)
      return autoCompleteNames.value.filter((f: any) => f.name.toLowerCase().includes(nameToSearch.value));
    
    return autoCompleteNames.value;
  })

  async function populateAutoCompleteNames() {
    loading.value = true;
    const response = await fetch(`https://localhost:44352/api/recipes`, {
      headers: {
        accept: "application/json",
      },
    });
    const data = await response.json();
    loading.value = false;

    for (const item of data) {
      autoCompleteNames.value.push({id: item.id,name: item.name});
    }
  }

  async function searchForFly(searchId: string) {
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

  // async function searchForFly(searchId: string) {
  //   foundFly.value.data = flys.value.find((f: any) => f.id === searchId);
  // }

  return {
    loading: computed(() => loading.value),
    fly: computed(() => fly),
    populateAutoCompleteNames,
    filteredNames,
    searchForFly,
    nameToSearch
  };
}
