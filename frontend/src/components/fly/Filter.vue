<template>
  <div>
      <input type="text" v-model="searchTerm">
  </div>
</template>

<script >
import { ref, watch } from 'vue';
import { useFlys } from '@/composables/useFlys';

export default {
    setup() {
        const searchTerm = ref('');
        const {filter} = useFlys();

        watch(searchTerm, function(newValue) {
            filter(newValue);
        })

        return {
            searchTerm,
        }
    }
}
</script>

<style>

</style>