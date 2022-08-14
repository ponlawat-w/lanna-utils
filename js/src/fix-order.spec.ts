import fixOrder from "./fix-order";
import { readCsv } from "./tests/io";

type TestCase = { input: string, expected: string };

describe('Test Fix Order', () => {
  let testCases: TestCase[];

  beforeAll(async() => {
    testCases = await readCsv('../TestCases/FixOrder.csv', row => ({input: row.input, expected: row.expected}));
  });

  it('should fix order correctly', () => {
    for (const testCase of testCases) {
      expect(fixOrder(testCase.input)).toEqual(testCase.expected);
    }
  });
});
