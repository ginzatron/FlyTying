<template>
  <section>
    <div class="title">
      <h2>{{ name }} total:<span>{{ count }}</span></h2>
    </div>
  </section>
</template>

<script>
import {reactive} from 'vue';

export default {
  props: ["name", "count"],
  // setup(props) {
  //     const counts = reactive({
  //         name: '',
  //         count: 0
  //     });

  //   // console.log(props.count);
  //   //   for(const val in props.count){
  //   //       console.log(val);
  //   //   }
  // }
};
</script>

<style scoped>
</style>