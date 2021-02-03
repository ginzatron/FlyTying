<template>
  <section>
    <div @click="selectFacet">{{ title }} <span v-if="count">({{ count }})</span></div>
  </section>
</template>

<script>
import { ref } from "vue";

export default {
  props: ["title", "count", "group"],
  emits: ["facetSelected"],

  setup(props, { emit }) {
    const facetTitle = ref(props.title);
    const facetCount = ref(props.count);
    const facetGroup = ref(props.group);

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
    };
  },
};
</script>

<style scoped>
.selected {
  color: blueviolet;
}
</style>