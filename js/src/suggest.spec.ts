import Lexicon from './lexicon';
import Suggestion, { SuggestionResult } from './suggest';
import { readCsv } from './tests/io';

type TestCase = {
  input: string,
  expectedIncluding: string,
  remaining: string
};

describe('Text Suggestions', () => {
  const lexicon: Lexicon = new Lexicon;
  const suggestion: Suggestion = new Suggestion(lexicon);
  let testCases: TestCase[];

  beforeAll(async() => {
    testCases = await readCsv('../TestCases/Suggestions.csv', row => ({input: row.input, expectedIncluding: row.expectedIncluding, remaining: row.remaining}));
  });

  it('should include expected word in the suggestion list', () => {
    for (const testCase of testCases) {
      const results: SuggestionResult[] = suggestion.suggest(testCase.input);
      const resultTexts: string[] = results.map(x => x.text);
      expect(resultTexts).toContain(testCase.expectedIncluding);

      const result = results.filter(x => x.text === testCase.expectedIncluding);
      expect(result[0].remaining).toEqual(testCase.remaining);
    }
  });

  it('should return empty list when input is empty', () => {
    expect(suggestion.suggest('').length).toBeFalsy();
  });
});
