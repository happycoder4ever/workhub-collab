import { describe, expect, it } from 'vitest';

describe('project service shape', () => {
  it('expects the API URL fallback to include http', () => {
    const apiUrl = import.meta.env.VITE_API_URL ?? 'http://localhost:5000';
    expect(apiUrl).toContain('http');
  });
});
