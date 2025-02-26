<template>
  <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
    <div class="navbar-container">
      <div class="navbar-left">
        <a class="navbar-brand" href="#">
          <i class="fas fa-jedi"></i> Star Wars Explorer
        </a>
      </div>
      <div class="navbar-center">
        <form class="search-form" @submit.prevent="search">
          <input class="search-input" type="search" placeholder="Search characters" aria-label="Search" v-model="searchQuery">
          <button class="search-button" type="submit">
            <i class="fas fa-search"></i>
          </button>
          <button class="clear-button" type="button" @click="clearSearch">
            <i class="fas fa-times"></i>
          </button>
        </form>
      </div>
      <div class="navbar-right">
        <ul class="navbar-nav">
          <li class="nav-item">
            <router-link class="nav-link" to="/">Home</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" to="/characters">Characters</router-link>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
import axios from 'axios';
import eventBus from '../eventBus';

export default {
  name: 'NavBar',
  data() {
    return {
      searchQuery: ''
    };
  },
  methods: {
    search() {
      if (this.searchQuery.trim() === '') {
        return;
      }

      const url = `${process.env.VUE_APP_API_URL}/starwars/search?name=${encodeURIComponent(this.searchQuery)}`;

      axios.get(url)
        .then(() => {
          eventBus.emit('search-results', this.searchQuery);
          if (this.$route.name === 'CharacterDetail') {
            this.$router.push({ name: 'Characters', query: { search: this.searchQuery } });
          } else {
            this.$router.push({ query: { search: this.searchQuery } });
          }
        })
        .catch(error => {
          console.error("Error during search:", error);
        });
    },
    clearSearch() {
      this.searchQuery = '';
      eventBus.emit('search-results', '');
      this.$router.push({ name: 'Characters' });
    }
  }
};
</script>

<style scoped>
.navbar {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 10%;
  background-color: #2c2f31;
}

.navbar-container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  max-width: 1200px;
}

.navbar-left,
.navbar-right {
  display: flex;
  align-items: center;
}

.navbar-center {
  flex-grow: 1;
  display: flex;
  justify-content: center;
}

.navbar-brand {
  font-family: 'Star Jedi', sans-serif; 
  font-size: 1.5em;
  color: rgba(232, 230, 227, 0.5);
  display: flex;
  align-items: center;
}

.navbar-brand i {
  margin-right: 10px;
}

.navbar-nav {
  display: flex;
  list-style: none;
  padding-left: 0;
  margin-bottom: 0;
}

.nav-item {
  margin-right: 15px;
}

.nav-link {
  color: #FFFFFF;
  text-decoration: none;
}

.nav-link:hover {
  text-decoration: underline;
}

.search-form {
  display: flex;
  align-items: center;
  border: 2px solid #7b7265;
  border-radius: 25px;
  padding: 5px 10px;
  background-color: #262829; 
  width: 100%;
  max-width: 500px;
}

.search-input {
  border: none;
  outline: none;
  box-shadow: none;
  border-radius: 25px;
  padding: 5px 10px;
  flex-grow: 1;
  background-color: #262829; 
  color: #FFFFFF;
}

.search-input::-webkit-search-cancel-button {
  -webkit-appearance: none;
  appearance: none;
}

.search-button {
  background: none;
  border: none;
  color: #ffd700; 
  cursor: pointer;
  padding: 0 10px;
}

.search-button i {
  font-size: 1.2em;
}

.clear-button {
  background: none;
  border: none;
  color: #ffd700; 
  cursor: pointer;
  padding: 0 10px;
}

.clear-button i {
  font-size: 1.2em;
}
</style>