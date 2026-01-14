const { env } = require('process');

// Determine backend target URL from environment variables or use default
const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:5053';

// Proxy configuration for Angular dev server
const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/api"  // Proxy all /api requests to backend
    ],
    target,
    secure: false  // Allow self-signed certificates in development
  }
]

module.exports = PROXY_CONFIG;
