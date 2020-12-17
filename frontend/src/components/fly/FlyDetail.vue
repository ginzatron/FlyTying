<template>
  <h1>{{st}}</h1>
  <h2>{{ payload.data.name}}</h2>
</template>

<script>
import {ref, reactive, onMounted} from 'vue';

export default {
    props: ['id'],
    setup(props){
        const st = ref('test');
        const payload = reactive({
            loading: false,
            error: '',
            data: {}
        });
        
        async function getFly() {
            payload.loading = true;
            payload.data = {};
            const response = await fetch(`https://localhost:44352/api/recipes/${props.id}`,{
                headers: {
                    accept: 'application/json',
                }
            });
            if(!response.ok){
                payload.error = 'could not complete request';
            }
            const data = await response.json();
            payload.loading = false;
            payload.data = data;
        }

        onMounted(getFly);

        return {
            payload,
            st,
        }
    }
}
</script>

<style>

</style>