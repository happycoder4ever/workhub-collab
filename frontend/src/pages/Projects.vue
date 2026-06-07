<template>
  <main class="page-container">
    <div class="page-header">
      <div>
        <h1>Projects</h1>
        <p>Manage sample project records with CRUD operations.</p>
      </div>
      <button @click="toggleCreate" class="primary-button">New Project</button>
    </div>

    <ProjectForm
      v-if="showForm"
      :project="selectedProject"
      @save="handleSave"
      @cancel="handleCancel"
    />

    <section class="projects-list">
      <div v-if="isLoading">Loading projects...</div>
      <div v-else-if="error" class="error">{{ error }}</div>
      <div v-else-if="projects.length === 0">No projects found.</div>
      <ul v-else>
        <li v-for="project in projects" :key="project.id" class="project-card">
          <div>
            <h2>{{ project.name }}</h2>
            <p>{{ project.description || 'No description yet' }}</p>
            <small>Created {{ new Date(project.createdAt).toLocaleString() }}</small>
          </div>
          <div class="project-actions">
            <button @click="editProject(project)">Edit</button>
            <button @click="removeProject(project.id)" class="danger-button">Delete</button>
          </div>
        </li>
      </ul>
    </section>
  </main>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { fetchProjects, createProject, updateProject, deleteProject } from '../services/projectService';
import type { Project } from '../types/project';
import ProjectForm from '../components/ProjectForm.vue';

const projects = ref<Project[]>([]);
const isLoading = ref(true);
const error = ref<string | null>(null);
const showForm = ref(false);
const selectedProject = ref<Project | null>(null);

async function loadProjects() {
  isLoading.value = true;
  error.value = null;

  try {
    projects.value = await fetchProjects();
  } catch (err) {
    error.value = (err as Error).message;
  } finally {
    isLoading.value = false;
  }
}

function toggleCreate() {
  selectedProject.value = null;
  showForm.value = true;
}

function editProject(project: Project) {
  selectedProject.value = project;
  showForm.value = true;
}

async function removeProject(id: string) {
  try {
    await deleteProject(id);
    await loadProjects();
  } catch (err) {
    error.value = (err as Error).message;
  }
}

async function handleSave(project: { name: string; description?: string }) {
  try {
    if (selectedProject.value) {
      await updateProject(selectedProject.value.id, project);
    } else {
      await createProject(project);
    }

    showForm.value = false;
    selectedProject.value = null;
    await loadProjects();
  } catch (err) {
    error.value = (err as Error).message;
  }
}

function handleCancel() {
  showForm.value = false;
  selectedProject.value = null;
}

onMounted(loadProjects);
</script>
