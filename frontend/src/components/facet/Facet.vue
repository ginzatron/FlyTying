<template>
  <section>
    <div class="title">
      <h2 @click="facetSelected">{{ facet }}</h2>
    </div>
  </section>
</template>

<script>
export default {
  props: ["facet"],

  setup(props,context) {
    async function facetSelected() {
      context.emit('setFacet',props.facet);
    }

    return {
      facetSelected
    }
  }
  
};
</script>

<style scoped>
</style>