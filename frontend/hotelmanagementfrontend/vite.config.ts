/// <reference types="vitest/config" />
// You can also try just /// <reference types="vitest" /> if the first one doesn't work

import { defineConfig } from 'vite' // Keep importing from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  // 👈 The 'test' block must be a top-level property
  test: {
    globals: true,
    environment: 'jsdom',
    setupFiles: './src/setupTests.ts',
  },
  server: {
    fs: {
      strict: false,
    },
  },
  build: {
    rollupOptions: {
      input: './index.html',
    },
  },
})
