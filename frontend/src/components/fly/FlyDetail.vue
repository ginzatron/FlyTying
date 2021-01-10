<template>
  <div class="fly-content">
    <h2 v-if="fly.loading">LOADING</h2>
    <h2 v-else-if="!fly.loading && fly.error === ''">
      <h3>{{ fly.data.name }}</h3>
    <div>
      <h5 v-for="material in fly.data.supplies" :key="material.name">
        {{material.name}}
      </h5>
    </div>
    </h2>
    <h2 v-if="fly.error !== ''">{{ fly.error }}</h2>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import { useFlys } from '@/composables/useFlys';

export default {
  props: ["id"],
  setup(props) {
    const {getFly, fly} = useFlys();
    const flyId = ref(props.id);

    onMounted(getFly(flyId.value));

    return {
      fly,
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