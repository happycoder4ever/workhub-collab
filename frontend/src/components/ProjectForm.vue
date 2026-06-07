<template>
  <section class="form-panel">
    <h2>{{ project ? 'Edit project' : 'Create project' }}</h2>
    <form @submit.prevent="onSubmit">
      <label>
        Name
        <input v-model="state.name" required />
      </label>

      <label>
        Description
        <textarea v-model="state.description" rows="3"></textarea>
      </label>

      <div class="form-actions">
        <button type="button" @click="cancel">Cancel</button>
        <button type="submit" class="primary-button">Save</button>
      </div>
    </form>
  </section>
</template>

<script setup lang="ts">
import { computed, defineProps, defineEmits, reactive, watchEffect } from 'vue';
import type { Project } from '../types/project';

const props = defineProps<{ project: Project | null }>();
const emit = defineEmits<{
  (e: 'save', payload: { name: string; description?: string }): void;
  (e: 'cancel'): void;
}>();

const state = reactive({
  name: '',
  description: '',
});

watchEffect(() => {
  state.name = props.project?.name ?? '';
  state.description = props.project?.description ?? '';
});

const title = computed(() => (props.project ? 'Update project' : 'Create project'));

function onSubmit() {
  emit('save', { name: state.name.trim(), description: state.description.trim() || undefined });
}

function cancel() {
  emit('cancel');
}
</script>
