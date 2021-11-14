<template>
  <section>
    <div @click="selectFacet">{{ title }} <span v-if="!facetSelected">({{ count }})</span></div>
  </section>
  <div></div>
</template>

<script lang="ts">
import { ref } from "vue";

export default {
  props: ["title", "count", "group","selected"],
  emits: ["facetSelected"],

  setup(props, { emit }) {
    const facetTitle = ref(props.title);
    const facetCount = ref(props.count);
    const facetGroup = ref(props.group);
    const facetSelected = ref(props.selected);

    async function selectFacet() {
      const info = {
        title: facetTitle.value,
        group: facetGroup.value,
      };
      emit("facetSelected", info);
    }

    return {
      facetTitle,
      facetCount,
      selectFacet,
      facetSelected
    };
  },
};
</script>

<style scoped>
</style>