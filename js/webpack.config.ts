import path from 'path';
import { Configuration } from 'webpack';

export default {
  entry: {
    'ambiguous-description': './dist/module/ambiguous-description.js',
    'fix-order': './dist/module/fix-order.js',
    'lexicon': './dist/module/lexicon.js',
    'suggest': './dist/module/suggest.js',
    'text-segment': './dist/module/text-segment.js'
  },
  output: {
    path: path.join(__dirname, 'dist', 'pack'),
    filename: 'lanna-utils.[name].js'
  }
} as Configuration;
