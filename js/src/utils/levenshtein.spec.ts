import levenshtein from './levenshtein';

describe('Levenshtein', () => {
  it('correctly calculates', () => {
    expect(levenshtein('kitten', 'sitting')).toBe(3);
    expect(levenshtein('Saturday', 'Sunday')).toBe(3);
    expect(levenshtein('party', 'park')).toBe(2);
    expect(levenshtein('monkey', 'money')).toBe(1);
    expect(levenshtein('rick', 'irkc')).toBe(3);
    expect(levenshtein('rick', 'rcik')).toBe(2);
    expect(levenshtein('rcik', 'irkc')).toBe(4);
    expect(levenshtein('elephant', 'relevant')).toBe(3);
    expect(levenshtein('lanna', 'lanna')).toBe(0);
  });
});
