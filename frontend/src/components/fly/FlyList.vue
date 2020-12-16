<template>
  <button @click="getFlys">GetFlys</button>
</template>

<script>
import {ref} from 'vue';

export default {
    setup(){
        const flys = ref([]);

        async function getFlys(){
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
            getFlys
        }
    }

}
</script>

<style>

</style>