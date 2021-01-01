<template>
  <div class="fly-content">
    <h2 v-if="foundFly.loading">LOADING</h2>
    <h2 v-else-if="!foundFly.loading && foundFly.error === ''">
      <h3>{{ foundFly.data.name }}</h3>
    <div>
      <h5 v-for="material in foundFly.data.supplies" :key="material.name">
        {{material.name}}
      </h5>
    </div>
    </h2>
    <h2 v-if="foundFly.error !== ''">{{ foundFly.error }}</h2>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import { useFlys } from '@/composables/useFlys';

export default {
  props: ["id"],
  setup(props) {
    const {flys, search, foundFly} = useFlys();
    const flyId = ref(props.id);

    onMounted(search(flyId.value));

    return {
      foundFly,
    };
  },
};
</script>

<style scoped>
.fly-content {
  display: flex;
  justify-content: center;
}
</style>