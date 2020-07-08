const path = require("path");
const webpack = require("webpack");
const { merge } = require("webpack-merge");
const CommonConfig = require("./webpack.common.js");
const TerserJSPlugin = require("terser-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");

// Images, Fonts Loading: https://webpack.js.org/guides/asset-management/
// LESS Loading: https://webpack.js.org/loaders/less-loader/
// Code splitting: https://webpack.js.org/guides/code-splitting
// Caching: https://webpack.js.org/guides/caching/

module.exports = merge(CommonConfig, {
  devtool: "inline-source-map",
  mode: "production",
  optimization: {
    minimizer: [new TerserJSPlugin({}), new OptimizeCSSAssetsPlugin({})],
    splitChunks: {
      chunks: "all",
    },
  },
  entry: {
    index: path.resolve(__dirname, "../src/index.ts")
  },

  output: {
    filename: "[name].[chunkhash].js",
    path: path.resolve(__dirname, "../dist"),
    // Making sure the CSS and JS files that are split out do not break the template cshtml.
    publicPath: "/Client/dist/",
    // Defining a global var that can used to call functions from within ASP.NET Razor pages.
    library: "aspAndWebpack",
    libraryTarget: "var",
  },

  module: {
    rules: [
      // All css files will be handled here
      {
        test: /\.css$/,
        use: [MiniCssExtractPlugin.loader, "css-loader", "postcss-loader"],
      },
    ],
  },

  plugins: [
    new webpack.DefinePlugin({
      "process.env": {
        NODE_ENV: JSON.stringify("production"),
      },
    }),

    // Split out library into seperate bundle and remove from app bundle.
    new webpack.HashedModuleIdsPlugin(),
    new MiniCssExtractPlugin({
      filename: "[name].css",
      chunkFilename: "[id].css",
    }),

    new webpack.LoaderOptionsPlugin({
      minimize: true,
      debug: false,
    }),
  ],
});
