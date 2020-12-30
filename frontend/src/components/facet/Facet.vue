<template>
  <section>
    <div class="title">
      <h2 @click="matchSearch">{{ name }} total:<span>{{ count }}</span></h2>
    </div>
  </section>
</template>

<script>
import {reactive} from 'vue';

export default {
  props: ["name", "count"],

  setup(props,context) {
    const matchSearch = function () {
      context.emit('matchSearch',props.name);
    }

    return {
      matchSearch
    }
  }
  
};
</script>

<style scoped>
</style>