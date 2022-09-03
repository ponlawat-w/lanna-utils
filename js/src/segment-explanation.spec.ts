import segmentExplanation from './segment-explanation';
import { readCsv } from './tests/io';

type TestCase = {
  input: string,
  central: string,
  centralLeft: string,
  left: string,
  top: string,
  right: string,
  rightTop: string,
  rightBottom: string,
  bottom: string
};

describe('Test Segment Explanation', () => {
  let testCases: TestCase[];

  beforeAll(async() => {
    testCases = await readCsv('../TestCases/SegmentExplanation.csv',
      row => ({...(row as TestCase)}));
  });

  it('should correctly gets invalid results', () => {
    expect(segmentExplanation().valid).toBeFalsy();
    expect(segmentExplanation('ᨶᩦ᩵ᨸᩮ᩠ᨶᨡᩬᩴ᩶ᨤ᩠ᩅᩣ᩠ᨾᨴᩦ᩵ᨿᩣ᩠ᩅ᩻').valid).toBeFalsy();
  });

  it('shoult correctly get results', () => {
    for (const testCase of testCases) {
      const result = segmentExplanation(testCase.input);
      expect(result.valid).toBeTruthy();
      expect(testCase.central).toEqual(result.central);
      expect(testCase.centralLeft).toEqual(result.centralLeft);
      expect(testCase.left).toEqual(result.left);
      expect(testCase.top).toEqual(result.top);
      expect(testCase.right).toEqual(result.right);
      expect(testCase.rightTop).toEqual(result.rightTop);
      expect(testCase.rightBottom).toEqual(result.rightBottom);
      expect(testCase.bottom).toEqual(result.bottom);
    }
  });
});
