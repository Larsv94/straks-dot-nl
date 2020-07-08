const webpack = require("webpack");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const path = require("path");

module.exports = {
  entry: "../src/index.ts",
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: "ts-loader",
        exclude: /node_modules/,
      },
      {
        test: /\.(png|svg|jpg|gif)$/,
        use: ["file-loader"],
      },
      {
        test: /\.(woff|woff2|eot|ttf|otf)$/,
        use: [
          {
            loader: "file-loader",
          },
        ],
      },
      { test: /\.html$/, loader: "html-loader" },
      { enforce: "pre", test: /\.js$/, loader: "source-map-loader" },
    ],
  },
  resolve: {
    extensions: [".tsx", ".ts", ".js"],
  },
  plugins: [
    // make sure we allow any jquery usages outside of our webpack modules
    new webpack.ProvidePlugin({
      $: "jquery",
      jQuery: "jquery",
      "window.jQuery": "jquery",
    }),

    new CleanWebpackPlugin(),
    new webpack.NoEmitOnErrorsPlugin(),

    new HtmlWebpackPlugin({
      inject: "body",
      filename: path.resolve(__dirname, "../../Views/Shared/_Layout.cshtml"),
      template: "../Views/Shared/_Layout_Template.cshtml",
    }),
  ],
  stats: { colors: true },
};
