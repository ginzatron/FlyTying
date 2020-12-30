<template>
    <div class="sidenav">
        <facet-list></facet-list>
    </div>
</template>

<script>
import FacetList from '@/components/facet/FacetList.vue';

export default {
  components: { FacetList },
}
</script>

<style scoped>
.sidenav {
  width: 200px; /* Set the width of the sidebar */
  position: fixed; /* Fixed Sidebar (stay in place on scroll) */
  z-index: 1; /* Stay on top */
  top: 0; /* Stay at the top */
  left: 0;
  background-color:white; /* Black */
  padding-top: 150px;
  margin-left: 20px;
}
</style>