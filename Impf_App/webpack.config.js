const path = require('path');

module.exports = {
    entry: './src/typescript/site.ts',
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
    },
    output: {
        filename: 'site.js',
        path: path.resolve(__dirname, 'wwwroot/js'),
    },
};