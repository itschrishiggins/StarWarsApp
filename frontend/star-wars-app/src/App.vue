<template>
  <div id="app">
    <NavBar v-if="showNavBar" />
    <main>
      <router-view />
    </main>
  </div>
</template>

<script>
import NavBar from './components/NavBar.vue';

export default {
  name: 'App',
  components: {
    NavBar,
  },
  data() {
    return {
      showNavBar: true,
    };
  },
  watch: {
    $route(to) {
      this.showNavBar = to.path !== '/';
    },
  },
  created() {
    this.showNavBar = this.$route.path !== '/';
  },
};
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,300;0,400;0,500;0,700;1,100;1,300;1,400;1,500&display=swap');

body, html {
  height: 100%;
  margin: 0;
}

body {
  background-color: #121212;
  color: #FFFFFF;
  height: 100%;
  margin: 0;
}

#app {
  font-family: 'Poppins', sans-serif;
  display: flex;
  flex-direction: column;
  height: 100%;
}

main {
  flex: 1;
}
</style>