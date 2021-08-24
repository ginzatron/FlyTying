<template>
  <div class="fly-content">
    <h2 v-if="fly.loading">LOADING</h2>
    <h2 v-else-if="!fly.loading && fly.error === ''">
      <h3>{{ fly.data.name }}</h3>
      <div>
        <h5 v-for="material in fly.data.supplies" :key="material.name">
          {{ material.name }}
        </h5>
      </div>
    </h2>
    <h2 v-if="fly.error !== ''">{{ fly.error }}</h2>
  </div>
</template>

<script>
import { ref, onMounted, reactive } from "vue";

export default {
  props: ["id"],
  setup(props) {
    const flyId = ref(props.id);
    const fly = reactive({
      loading: false,
      error: "",
      data: {},
    });

    async function getFly(searchId) {
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

    onMounted(getFly(flyId.value));

    return {
      fly,
    };
  },
};
</script>

<style scoped>
.fly-content {
  display: flex;
  justify-content: center;
  background-color: green;
}
</style>