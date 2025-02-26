<template>
  <div class="character-list">
    <div class="character-container">
      <div class="character-card" v-for="character in localCharacters" :key="character.url"
        @click="goToCharacterDetail(character)">
        <h3>{{ character.name }}</h3>
        <p><strong>Birth Year:</strong> {{ character.birth_year }}</p>
        <p><strong>Height:</strong> {{ character.height }}cm</p>
        <p><strong>Weight:</strong> {{ character.mass }}kg</p>
      </div>
    </div>

    <button v-if="nextPage" @click="getNextPage" class="button-load-more">Load More</button>
  </div>
</template>

<script>
import axios from 'axios';
import eventBus from '../eventBus';

export default {
  data() {
    return {
      searchQuery: '',
      localCharacters: [],
      nextPage: null
    };
  },
  methods: {
    getCharacters() {
      axios.get(`${process.env.VUE_APP_API_URL}/starwars`)
        .then(response => {
          this.localCharacters = response.data.results; // Update the characters list
          this.nextPage = response.data.next; // Update next page URL
        })
        .catch(error => {
          console.error("Error fetching characters:", error);
        });
    },

    getNextPage() {
      if (this.nextPage) { 
        axios.get(this.nextPage)
          .then(response => {
            this.localCharacters = this.localCharacters.concat(response.data.results); // Append new characters to existing list
            this.nextPage = response.data.next; 
          })
          .catch(error => {
            console.error("Error fetching next page:", error);
          });
      }
    },

    goToCharacterDetail(character) {
      let characterId = character.url.match(/\/api\/people\/(\d+)/)[1]; // Get character ID from URL      
      this.$router.push({ path: `/characters/${characterId}` }); 
    },

    searchCharacters(query) {
      if (query.trim() === '') { // Check if search query is not empty
        this.getCharacters(); // Return all characters if query is empty
        return;
      }

      const url = `${process.env.VUE_APP_API_URL}/starwars/search?name=${encodeURIComponent(query)}`;

      axios.get(url)
        .then(response => {
          this.localCharacters = response.data.results; // Update character list with search results
          this.nextPage = response.data.next; 
        })
        .catch(error => {
          console.error("Error during search:", error);
        });
    }
  },
  watch: {
    '$route.query.search': function(newQuery) {
      this.searchCharacters(newQuery || '');
    }
  },
  mounted() {
    this.searchCharacters(this.$route.query.search || '');
    eventBus.on('search-results', (query) => {
      this.$router.push({ name: 'Characters', query: { search: query } });
    });
  }
};
</script>

<style scoped>
.character-list {
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background-color: #202325;
  padding: 20px;
  
}

.character-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  width: 100%;
  align-items: center;
}

.character-card {
  background-color: #181a1b;
  border-radius: 10px;
  padding: 20px;
  margin: 10px;
  width: 275px;
  height: 225px; 
  box-shadow: 0 3px 6px rgba(0, 0, 0, 0.15);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  cursor: pointer;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.character-card:hover {
  transform: scale(1.05);
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.25);
}

.character-card h3 {
  color: #ffd700;
  font-size: 1.4em;
  margin-bottom: 15px;
}

.character-card p {
  color: #dcdcdc;
  margin: 5px 0;
  line-height: 1.4;
}

.button-load-more {
  display: block;
  margin: 30px auto;
  padding: 12px 25px;
  background-color: #2c2f31;
  color: #ffd700;
  border: 2px solid #ffd700;
  border-radius: 20px;
  cursor: pointer;
  transition: background-color 0.3s ease, color 0.3s ease;
}

.button-load-more:hover {
  background-color: #ffd700;
  color: #2c2f31;
}
</style>