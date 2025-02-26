<template>
  <div class="character-details-outer-wrapper">
    <div class="button-container">
      <button @click="goBack" class="btn btn-outline-light mb-3">
        <i class="fas fa-circle-left"></i>&nbsp; Back
      </button>
    </div>
    <div class="character-details-wrapper">
      <div class="character-details" v-if="character.id">
        <img :src="`/img/${character.id}.jpg`" />
        <div class="character-info">
          <h2>{{ character.name }}</h2>
          <div class="character-details-info">
            <p><strong>Gender:</strong> {{ capitalize(character.gender) }}</p>
            <p><strong>Birth Year:</strong> {{ character.birth_year }}</p>
            <p><strong>Height:</strong> {{ character.height }}cm</p>
            <p><strong>Weight:</strong> {{ character.mass }}kg</p>
            <p><strong>Hair Color:</strong> {{ capitalize(character.hair_color) }}</p>
            <p><strong>Skin Color:</strong> {{ capitalize(character.skin_color) }}</p>
            <p><strong>Eye Color:</strong> {{ capitalize(character.eye_color) }}</p>
          </div>
        </div>
      </div>
      <div v-else>
        Loading character details...
      </div>
    </div>
    <div class="navigation-buttons">
      <button v-if="previousCharacter" @click="goToCharacter(parseInt(character.id) - 1)" class="btn btn-dark previous-button">
        <i class="fas fa-arrow-left"></i>&nbsp; Previous: {{ previousCharacter.name }}
      </button>
      <button v-if="nextCharacter" @click="goToCharacter(parseInt(character.id) + 1)" class="btn btn-dark next-button">
        Next: {{ nextCharacter.name }}&nbsp;<i class="fas fa-arrow-right"></i>
      </button>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import eventBus from '../eventBus';

export default {
  data() {
    return {
      character: {},
      previousCharacter: null,
      nextCharacter: null
    };
  },
  async mounted() {
    await this.getCharacterDetails();
    eventBus.on('search-results', (query) => {
      this.$router.push({ name: 'Characters', query: { search: query } });
    });
  },
  watch: {
    '$route.params.id': 'getCharacterDetails'
  },
  methods: {
    async getCharacterDetails() {
      const characterId = this.$route.params.id; // Get character ID from route parameters
      try {
        const response = await axios.get(`${process.env.VUE_APP_API_URL}/starwars/${characterId}`);
        this.character = { id: characterId, ...response.data }; // Update character data
        await this.getAdjacentCharacters(characterId);
      } catch (error) {
        console.error(error);
      }
    },
    async getAdjacentCharacters(characterId) {
      try {
        const response = await axios.get(`${process.env.VUE_APP_API_URL}/starwars`);
        const characters = response.data.results; // Access results array
        if (Array.isArray(characters)) {
          const index = characters.findIndex(character => character.url.split('/').slice(-2, -1)[0] === characterId);
          this.previousCharacter = characters[index - 1] || null;
          this.nextCharacter = characters[index + 1] || null;
        } else {
          console.error('Expected an array of characters');
        }
      } catch (error) {
        console.error(error);
      }
    },
    goToCharacter(characterId) {
      this.$router.push(`/characters/${characterId}`);
    },
    goBack() {
      this.$router.push('/characters');
    },
    capitalize(value) {
      if (!value) return '';
      return value.charAt(0).toUpperCase() + value.slice(1);
    }
  }
};
</script>

<style scoped>
.character-details-outer-wrapper {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
  min-height: 100%;
  background-color: #202325;
  padding: 20px;
  padding-top: 136px;
}

.button-container {
  align-self: flex-start;
  margin-bottom: 20px;
}

.character-details-wrapper {
  display: flex;
  align-items: flex-start;
}

.btn-primary {
  width: 100px;
  margin-bottom: 0;
}

.character-details {
  background-color: #181a1b;
  border-radius: 10px;
  box-shadow: 0 3px 6px rgba(0, 0, 0, 0.15);
  padding: 20px;
  max-width: 900px;
  width: 100%;
  display: flex;
  align-items: center;
  flex-wrap: wrap;
}

.character-details img {
  max-width: 50%;
  border-radius: 10px;
  margin-right: 20px;
  margin-bottom: 20px;
}

.character-info {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  flex: 1;
  max-width: 50%;
  height: 100%;
}

.character-info h2 {
  color: #ffd700;
  font-size: 2.5em;
  margin-bottom: 20px;
}

.character-details-info {
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  flex-grow: 1;
}

.character-details-info p {
  color: #6b6b6b;
  margin-bottom: 5px;
  line-height: 1.4;
}

.character-details-info p strong {
  color: #9a9a9a;
  font-weight: bold;
  margin-right: 5px;
}

.navigation-buttons {
  display: flex;
  justify-content: space-between;
  width: 100%;
  margin-top: 20px;
}

.previous-button {
  position: absolute;
  bottom: 20px;
  left: 20px;
}

.next-button {
  position: absolute;
  bottom: 20px;
  right: 20px;
}

@media (max-width: 600px) {
  .character-details-outer-wrapper {
    flex-direction: column;
    align-items: center;
  }

  .button-container {
    top: 10px;
    left: 10px;
  }

  .character-details {
    flex-direction: column;
    align-items: center;
  }

  .character-details img {
    margin-right: 0;
    margin-bottom: 20px;
    max-width: 100%;
  }

  .character-info {
    max-width: 100%;
  }

  .navigation-buttons {
    flex-direction: column;
    align-items: center;
  }

  .navigation-buttons button {
    margin-bottom: 10px;
  }

  .previous-button {
    position: static;
    margin-bottom: 10px;
  }

  .next-button {
    position: static;
  }
}
</style>
