<template>
  <h2 v-if="payload.loading">LOADING</h2>
  <h2 v-else-if="!payload.loading && payload.error === ''">{{ payload.data.name }}</h2>
  <h2 v-if="payload.error !== ''">{{ payload.error }}</h2>
</template>

<script>
import { ref, reactive, onMounted, watch } from 'vue';
import { useRoute } from 'vue-router';

export default {
  props: ["id"],
  setup(props) {
    const flyId = ref(props.id);
    const route = useRoute();
    const payload = reactive({
      loading: false,
      error: "",
      data: {},
    });

    async function getFly(id) {
      payload.loading = true;
      payload.data = {};
      const response = await fetch(
        `https://localhost:44352/api/recipes/${id}`,
        {
          headers: {
            accept: "application/json",
          },
        }
      );
      if (!response.ok) {
        payload.error = "could not complete request";
      }
      const data = await response.json();
      payload.loading = false;
      payload.data = data;
    }

    watch (() => route.params, (newRoute) => {
      if (newRoute.id)
        getFly(newRoute.id);
    });

    onMounted(getFly(flyId.value));

    return {
      payload,
    };
  },
};
</script>

<style>
</style>