<template>
  <div class="facets">
    <h3>Facets</h3>
    <facet
      v-for="facet in facetItems"
      :key="facet.title"
      :title="facet.title"
      :count="facet.count"
      :group="facet.group"
      :selected="facet.selected"
      @facetSelected="passUp"
    >
    </facet>
  </div>
</template>

<script>
import { ref } from "vue";
import Facet from "@/components/facet/Facet.vue";

export default {
  components: { Facet },
  props: ["facets"],
  emits: ["facetSelected"],
  setup(props, { emit }) {
    const facetItems = ref(props.facets);

    async function passUp(info) {
      emit("facetSelected", info);
    }

    return {
      passUp,
      facetItems,
    };
  },
};
</script>

<style scoped>
.facets {
  display: flex;
  flex-direction: column;
}
</style>