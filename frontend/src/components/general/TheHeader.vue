<template>
  <header>
    <div class="logo">
      <router-link :to="{name: 'Home'}">VISE LOGO</router-link>
    </div>
    <!-- <div id="g-signin2" data-onsuccess="onSignIn"></div>
      <a href="#" onclick="signOut();">Sign out</a> -->
    <!-- <nav>
      <ul class="nav-links">
        <li id="getFlys"><router-link to="/flys">Flys</router-link></li>
        <li><a href="#">Create Flys</a></li>
      </ul>
    </nav> -->
      <div class="create">
        <button @click="saveNewFly" >Create a new Fly</button>
        <input type="text" v-model="newFly" />
      </div>
      <a class="contact-button" href="#" type="button">Contact</a>
  </header>
</template>

<script>
import { ref } from "vue";

export default {
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
}
</script>

<style scoped>
header {
  display: flex;
  justify-content: flex-end;
  align-items: center;
  padding: 30px 10%;
  background: red;
  width: 100%;
}

.create {
  display: flex;
  flex-direction: column;
}

.logo {
  cursor: pointer;
  margin-right: auto;
  margin-left: 80px;
}

.contact-button {
  margin-left: 8px;
}

a {
  text-decoration: none;
}

</style>