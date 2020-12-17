<template>
  <button @click="getFlys">GetFlys</button>
  <div v-for="fly in flys" :key="fly.id">
      <h3><router-link to="/flys/5fd8efc98a32644a6388059a">{{ fly.name }}</router-link></h3> 
  </div>
</template>

<script>
import {ref} from 'vue';

export default {
    setup(){
        const flys = ref([]);

        async function getFlys(){
            // const route = useRoute();
            const response = await fetch(`https://localhost:44352/api/recipes`,{
                headers: {
                    accept: 'application/json',
                }
            });
            const data = await response.json();

            flys.value = data;
        }

        return {
            flys,
            getFlys,
        }
    }

}
</script>

<style>

</style>