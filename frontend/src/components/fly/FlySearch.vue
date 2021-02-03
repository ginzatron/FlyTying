<template>
  <div>
      <input type="search" v-model="searchTerm">
  </div>
</template>

<script>
import { computed } from 'vue';

export default {
    emits: ['update:modelValue'],
    props: ['modelValue'],
    setup(props,{emit}) {
        const searchTerm = computed({
            get: () => props.modelValue,
            set: (value) => emit('update:modelValue', value)
        })

        return {
            searchTerm
        }
    }
}
</script>

<style>

</style>