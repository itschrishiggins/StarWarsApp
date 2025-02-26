import { createRouter, createWebHistory } from 'vue-router';
import Home from '../components/HomeView.vue'; 
import CharacterListView from '../components/CharacterListView.vue'; 
import CharacterDetail from '../components/CharacterDetail.vue'; 


const routes = [
    {
        path: '/characters',
        name: 'Characters',
        component: CharacterListView
    },
    {
        path: '/characters/:id', 
        name: 'CharacterDetail', 
        component: CharacterDetail
    },
    {
        path: '/',
        name: 'Home',
        component: Home
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
  });

export default router;
