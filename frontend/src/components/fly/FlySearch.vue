<template>
  <div>
      <input type="search" v-model="searchTerm" @input="flySearch">
  </div>
</template>

<script>
import {ref} from 'vue';

export default {
    emits: ['flySearch'],
    setup(_,{emit}) {
        const searchTerm = ref('');

        function flySearch(){
            emit('flySearch',searchTerm.value);
        }

        return {
            searchTerm,
            flySearch
        }
    }
}
</script>

<style>

</style>