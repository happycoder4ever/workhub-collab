import type { Project } from '../types/project';

const baseUrl = import.meta.env.VITE_API_URL ?? 'http://localhost:5000';
const projectsEndpoint = `${baseUrl}/api/projects`;

export async function fetchProjects(): Promise<Project[]> {
  const response = await fetch(projectsEndpoint);
  if (!response.ok) {
    throw new Error('Unable to load projects');
  }
  return await response.json();
}

export async function createProject(payload: { name: string; description?: string }): Promise<Project> {
  const response = await fetch(projectsEndpoint, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(payload),
  });

  if (!response.ok) {
    throw new Error('Unable to create project');
  }

  return await response.json();
}

export async function updateProject(id: string, payload: { name: string; description?: string }): Promise<Project> {
  const response = await fetch(`${projectsEndpoint}/${id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(payload),
  });

  if (!response.ok) {
    throw new Error('Unable to update project');
  }

  return await response.json();
}

export async function deleteProject(id: string): Promise<void> {
  const response = await fetch(`${projectsEndpoint}/${id}`, {
    method: 'DELETE',
  });

  if (!response.ok) {
    throw new Error('Unable to delete project');
  }
}
