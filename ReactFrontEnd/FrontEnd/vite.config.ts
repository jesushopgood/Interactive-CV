import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import path from 'path';

export default defineConfig({
  plugins: [
    react({
      babel: {
        plugins: [
          [
            '@babel/plugin-proposal-decorators',
            { version: '2023-05', decoratorsBeforeExport: true }
          ]
        ]
      }
    })
  ],
  resolve: {
    alias: {
      'components': path.resolve(__dirname, '/src/components'),
    },
  }



});