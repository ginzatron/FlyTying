<template>
  <!-- Left half of page is searching, right is creating -->
  <div class="main">
    <div>
      <Filter></Filter>
    </div>
    <div>
      <fly-list></fly-list>
    </div>
  </div>
</template>     

<script>
import FlyList from "@/components/fly/FlyList.vue";
import Filter from '@/components/fly/Filter.vue';

export default {
  components: {
    FlyList,
    Filter
  },
  
};
</script>

<style scoped>
.main {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>