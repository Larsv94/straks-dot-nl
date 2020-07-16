const path = require("path");
const webpack = require("webpack");
const { merge } = require("webpack-merge");
const CommonConfig = require("./webpack.common.js");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

const WatchExternalFilesPlugin = require("webpack-watch-files-plugin").default;

module.exports = merge(CommonConfig, {
  mode: "development",
  //devtool: "inline-source-map",
  stats: "minimal",
  entry: path.resolve(__dirname, "../src/index.ts"),
  devServer: {
    contentBase: path.join(__dirname, "../dist"),
    compress: true,
    port: 8080,
    publicPath: "/Client/dist/",
    writeToDisk: true,
    clientLogLevel: "silent",
  },
  output: {
    filename: "bundle.js",
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
        use: [
          MiniCssExtractPlugin.loader,
          // Translates CSS into CommonJS
          {
            loader: "css-loader",
            options: {
              importLoaders: 1,
            },
          },
          "postcss-loader",
        ],
      },
    ],
  },

  plugins: [
    new webpack.DefinePlugin({
      "process.env": {
        NODE_ENV: JSON.stringify("development"),
      },
    }),
    new MiniCssExtractPlugin({
      filename: "[name].css",
      chunkFilename: "[id].css",
    }),
    new WatchExternalFilesPlugin({
      files: [
        path.resolve(__dirname, "../../**/*.cshtml"),
        `!${path.resolve(__dirname, "../../**/_Layout.cshtml")}`,
      ],
      verbose: true,
    }),
  ],
});
