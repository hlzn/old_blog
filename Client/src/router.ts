import { createRouter, createWebHistory } from "vue-router";
import FrontDoor from "./components/frontdoor/FrontDoor.vue";

const routes = [
    {
        path: '/',
        name: 'frontdoor',
        component: FrontDoor
    },
    {
        path: '/story/:storyid',
        name: 'story',
        component: FrontDoor
    },
    {
        path: '/about',
        name: 'about',
        component: FrontDoor
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;