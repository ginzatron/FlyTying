<template>
  <section>
    <div class="title" >
      <h2 @click="facetSelected" :class="{selected: isSelected}">{{ facet }}</h2>
    </div>
  </section>
</template>

<script>
import {ref} from 'vue';

export default {
  props: ["facet","selected"],
  emits: ['facetSelected'],

  setup(props,context) {
    const isSelected = ref(props.selected);

    async function facetSelected() {
      //isSelected.value = !isSelected.value;
      context.emit('facetSelected',props.facet);
    }

    return {
      facetSelected,
      isSelected
    }
  }
  
};
</script>

<style scoped>

.selected {
  color: blueviolet;
}

</style>