<template>
  <!-- Left half of page is searching, right is creating -->
  <div class="main">
    <div>
      <search-me></search-me>
      <fly-list></fly-list>
    </div>
  </div>
</template>     

<script>
import FlyList from "@/components/fly/FlyList.vue";
import SearchMe from '@/views/SearchMe';

export default {
  components: {
    FlyList,
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