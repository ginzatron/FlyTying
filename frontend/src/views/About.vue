<template>
  <div id="counter">
    <span>Counter: {{counter}}</span>
  </div>
</template>

<script>
  const Counter = {
    data(){
      return{
        count: 0        
      }
  }
}

Vue.createApp(Coutner).mount(#counter)
</script>
