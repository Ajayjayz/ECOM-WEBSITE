const { defineConfig } = require('@vue/cli-service')
module.exports = {
  devServer: {
    proxy: {
      '^/api': {
        target: 'https://localhost:7400',
        changeOrigin: true,
        secure: false // <- Accept self-signed HTTPS cert
      },
    },
  },
};