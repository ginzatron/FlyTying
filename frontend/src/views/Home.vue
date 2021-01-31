<template>
  <div class="main">
    <div>
      <search-me></search-me>
    </div>
  </div>
</template>     

<script>
import SearchMe from '@/views/SearchMe';

export default {
  components: {
    SearchMe,
  },
  
};
</script>

<style scoped>
.main {
  display: flex;
  flex-direction: column;
  align-items: center;
  background: green;
}
</style>