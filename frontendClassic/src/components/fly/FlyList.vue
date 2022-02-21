<template>
  <fly-search v-model="searchTerm"></fly-search>
  <div v-for="fly in filteredFlys" :key="fly.id">
    <h3>
      <router-link :to="{ name: 'Fly', params: { id: fly.id } }">{{
        fly.pattern.name
      }}</router-link>
    </h3>
  </div>
</template>

<script>
import { ref, computed } from "vue";
import FlySearch from "@/components/fly/FlySearch.vue";

export default {
  components: { FlySearch },
  props: ["list"],
  setup(props) {
    const flys = ref(props.list);
    const searchTerm = ref("");

    const filteredFlys = computed(() => {
      return flys.value.filter((f) =>
        f.name.toLowerCase().includes(searchTerm.value)
      );
    });

    return {
      filteredFlys,
      searchTerm,
    };
  },
};
</script>

<style></style>
