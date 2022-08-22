import ambiguousDescription from './ambiguous-description';
import { readCsv } from './tests/io';

type TestCase = {input: string, expected: string};

describe('Test Ambiguous Description', () => {
  let testCases: TestCase[];

  beforeAll(async() => {
    testCases = await readCsv('../TestCases/AmbiguousDescription.csv', row => ({input: row.input, expected: row.expected}));
  });

  it('should return a correct ambiguous description', () => {
    for (const testCase of testCases) {
      expect(ambiguousDescription(testCase.input)).toEqual(testCase.expected);
    }
  });

  it('should return empty for non-taitham', () => {
    expect(ambiguousDescription('test')).toBeFalsy();
    expect(ambiguousDescription(' ')).toBeFalsy();
  });
});
