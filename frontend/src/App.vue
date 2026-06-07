<template>
  <div class="app-shell">
    <aside class="side-nav">
      <div class="brand">
        <h1>WorkHub</h1>
      </div>
      <nav>
        <router-link to="/">Dashboard</router-link>
        <router-link to="/projects">Projects</router-link>
      </nav>
    </aside>

    <div class="content-area">
      <router-view />
    </div>
  </div>
</template>
