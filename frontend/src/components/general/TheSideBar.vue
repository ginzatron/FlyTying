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
  background: blue;
  width: 100%;
}
</style>