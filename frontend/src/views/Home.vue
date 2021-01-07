<template>
  <!-- Left half of page is searching, right is creating -->
  <div class="main">
    <div>
      <fly-list></fly-list>
    </div>
  </div>
</template>     

<script>
import FlyList from "@/components/fly/FlyList.vue";

export default {
  components: {
    FlyList,
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