module.exports = {
  transpileDependencies: true,
  devServer: {
    proxy: {
      '/api': {
        target: process.env.VUE_APP_API_URL, 
        changeOrigin: true,
      },
    },
  },
};
