<template>
<button @click="getFacets">Click me</button>
</template>

<script>
import {ref} from 'vue';

export default {
    setup() {
        const selectedFacets = ref({});
        selectedFacets.value["patterns"] = ["Steelhead", "Hopper"];
        selectedFacets.value["patternNames"] = ["RibHaresEar2", "RoyalWulff1"];

        const returnedRecipes = ref([]);
        const returnedFacetGroups = ref([]);
        
        async function getFacets() {
            const response = await fetch(`https://localhost:44352/api/recipes/facet`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    accept: "application/json",
                },
                body: JSON.stringify(selectedFacets.value)
            });
            const data = await response.json();
            console.log(data);

            returnedRecipes.value = data.recipes;
            returnedFacetGroups.value = data.facetGroups;

            console.log(returnedRecipes.value);
            console.log(returnedFacetGroups.value);
        }

        return {
            getFacets
        }
    }
}
</script>

<style>

</style>