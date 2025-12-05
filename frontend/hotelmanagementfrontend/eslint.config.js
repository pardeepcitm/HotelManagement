// eslint.config.js
import ts from '@typescript-eslint/eslint-plugin'
import tsParser from '@typescript-eslint/parser'
import react from 'eslint-plugin-react'
import reactHooks from 'eslint-plugin-react-hooks'
import prettier from 'eslint-plugin-prettier'
import globals from 'globals'

export default [
  {
    // Enable linting for these files
    files: ['**/*.{js,jsx,ts,tsx}'],

    languageOptions: {
      ecmaVersion: 'latest',
      sourceType: 'module',
      parser: tsParser,
      globals: {
        ...globals.browser,
        ...globals.node,
      },
    },

    plugins: {
      '@typescript-eslint': ts,
      react,
      'react-hooks': reactHooks,
      prettier,
    },

    settings: {
      react: {
        version: 'detect',
      },
    },

    rules: {
      // TS rules
      '@typescript-eslint/no-unused-vars': 'warn',

      // React rules
      'react/jsx-uses-react': 'off',
      'react/react-in-jsx-scope': 'off',

      // Hooks rules
      'react-hooks/rules-of-hooks': 'error',
      'react-hooks/exhaustive-deps': 'warn',

      // Prettier integration
      'prettier/prettier': 'error',
    },
  },

  {
    ignores: ['dist/**', 'build/**', 'node_modules/**'],
  },
]
