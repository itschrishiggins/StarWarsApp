<template>
  <div class="home">
    <h1>Star Wars 
      <br>Explorer</h1>
    <p>Discover the characters from the Star Wars universe!</p>
    <router-link to="/characters" class="explore-btn"><i class="fa-brands fa-space-awesome"></i>&nbsp;&nbsp;Explore</router-link>
  </div>
</template>
  
<script>
export default {
  name: 'HomeView'
};
</script>
  
<style scoped>
.home {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;
  text-align: center;
  background-image: url('/public/img/star-wars-background.jpeg');
  background-size: cover;
  background-position: center;
  color: white;
  padding: 3rem;
  border-radius: 0.625rem;
  box-shadow: 0 0.25rem 0.5rem rgba(0, 0, 0, 0.2);
}

.home h1 {
  font-size: 3rem;
  font-family: 'Star Wars', sans-serif;
  color: #ffd700;
  margin-bottom: 1.25rem;
  text-shadow: 5px 5px 10px rgba(0, 0, 0, 1);
}

.home p {
  font-size: 1.2rem;
  color: #dcdcdc;
  margin-bottom: 1.5rem;
  text-shadow: 5px 5px 10px rgba(0, 0, 0, 1);
}

.explore-btn {
  padding: .5rem 1rem;
  background-color: #ff6347;
  color: white;
  border-radius: 0.6rem;
  text-decoration: none;
  font-size: 1rem;
  transition: background-color 0.3s ease;
}

.explore-btn:hover {
  background-color: #ff4a2b;
}
</style>
