import {computed, ref} from 'vue';

const flys = ref([]);

export function useFlys() {
    const loading = ref(false);

    async function getFlys() {
        const response = await fetch(`https://localhost:44352/api/recipes`, {
          headers: {
            accept: "application/json",
          },
        });
        loading.value = true;
        const data = await response.json();
        loading.value = false;
        flys.value = data;
      }

    return {
        flys: computed(() => flys.value),
        getFlys,
        loading: computed(() => loading.value)
    }
}