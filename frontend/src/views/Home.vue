<template>
  <!-- Left half of page is searching, right is creating -->
  <div class="main">
    <div class="search">
      <h3>Search by filtering</h3>
      <facet-list></facet-list>
    </div>
    <div>
      <fly-list></fly-list>
    </div>
    <div class="create">
      <button @click="saveNewFly" >Create a new Fly</button>
      <input type="text" v-model="newFly" />
    </div>
  </div>
</template>     

<script>
import { ref } from "vue";
import FacetList from "@/components/facet/FacetList.vue";
import FlyList from "@/components/fly/FlyList.vue";

export default {
  components: {
    FacetList,
    FlyList
  },
  setup() {
    const newFly = ref("");

    function saveNewFly() {
      console.log(`api call to save ${newFly.value}`);
    }

    return {
      saveNewFly,
      newFly,
    };
  },
};
</script>

<style scoped>
.main {
  display: flex;
  justify-content: space-evenly;
  align-content: center;
}

.create {
  display: flex;
  flex-direction: column;
}
</style>