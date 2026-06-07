import { createRouter, createWebHistory } from 'vue-router';
import DashboardPage from '../pages/Dashboard.vue';
import ProjectsPage from '../pages/Projects.vue';

const routes = [
  { path: '/', name: 'Dashboard', component: DashboardPage },
  { path: '/projects', name: 'Projects', component: ProjectsPage },
];

export const router = createRouter({
  history: createWebHistory(),
  routes,
});
