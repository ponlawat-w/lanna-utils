import { readCsv } from './tests/io';
import textSegment from './text-segment';

type TestCase = {input: string, expected: string[]};

describe('Text Segmentation', () => {
  let testCases: TestCase[];

  beforeAll(async() => {
    testCases = await readCsv(
      '../TestCases/TextSegment.csv',
      row => ({input: row.input, expected: (row.expected.toString() as string).split('/').map(x => x.trim()).filter(x => x)}));
  });

  it('should split text to segments correctly', () => {
    for (const testCase of testCases) {
      expect(textSegment(testCase.input)).toEqual(testCase.expected);
    }
  });
});
