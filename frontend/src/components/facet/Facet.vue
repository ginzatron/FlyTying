<template>
  <section>
    <div class="title" >
      <label :class="{selected: facetSelected}">{{ facetName }}</label>
      <input type="checkbox" v-model="facetSelected" @input="updateSelectedFacet">
    </div>
  </section>
</template>

<script>
import {ref, computed} from 'vue';

export default {
  props: ["facet","modelValue"],
  emits: ['update:modelValue','update'],

  setup(props,{emit}) {
    const facetName = ref(props.facet);

    const facetSelected = computed({
      get: () => props.modelValue,
      set: (value) => emit('update:modelValue',value)
    });

    async function updateSelectedFacet() {
      emit('update',facetName);
    }

    return {
      facetSelected,
      facetName,
      updateSelectedFacet
    }
  }
  
};
</script>

<style scoped>

.selected {
  color: blueviolet;
}

</style>