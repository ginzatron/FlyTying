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
    <a class="button" href="#" type="button">Contact</a>
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
  padding-bottom: 90px;
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

.nav-links {
  list-style: none;
}

.nav-links li {
  display: inline-block;
  padding: 0px 20px;
}

.nav-links li a {
  transition: all 0.3s ease 0s;
  text-decoration: none;
}

.nav-links li a:hover {
  color: #0088a9;
}

.button {
  margin-left: 20px;
  padding: 9px 25px;
  background-color: rgba(0, 136, 169, 1);
  border: none;
  border-radius: 50px;
  cursor: pointer;
  transition: all 0.3s ease 0s;
}

.button:hover {
  background-color: rgba(0, 136, 169, 0.8);
}

a {
  text-decoration: none;
}

</style>