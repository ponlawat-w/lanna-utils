import patterns from './resources/patterns';
import characters from './resources/characters';

const SpatialCharactersRegExp: RegExp = new RegExp(`^[${patterns.spatialCharacters}]$`);

export default function(text: string): string[] {
  const results: string[] = [];

  let segment = '';
  for (let i = 0; i < text.length; i++) {
    const currentChar: string = text[i];
    if (SpatialCharactersRegExp.test(currentChar) && i > 0 && text[i - 1] != characters.choengIndicator) {
      results.push(segment);
      segment = '';
    }

    segment += currentChar;
  }

  if (segment) {
    results.push(segment);
  }

  return results;
};
