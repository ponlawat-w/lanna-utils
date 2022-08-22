import Lexicon, { Word } from './lexicon';

describe('Word', () => {
  it('has ambiguous descriptions', () => {
    const word1 = new Word('ᨡᩮᩢ᩶ᩣᨴᩬᩁ');
    expect(word1.ambiguousDescription).toEqual('kaotoar');
    const word2 = new Word('ᨡᩮᩢ᩶ᩣᩃᩯ᩠ᨦ');
    expect(word2.ambiguousDescription).toEqual('kaolaeng');
  });

  it('compares', () => {
    const word1 = new Word('ᨡᩮᩢ᩶ᩣᨴᩬᩁ');
    const word2 = new Word('ᨡᩮᩢ᩶ᩣᩃᩯ᩠ᨦ');

    expect(word1.compareWord(word2.text)).toEqual(4);
    expect(word1.compareAmbiguousDescription(word2.ambiguousDescription)).toEqual(5);
  });
});

describe('Lexicon', () => {
  const lexicon = new Lexicon();

  it('is clean', () => {
    for (const word of lexicon.words) {
      expect(word.text).toBeTruthy();
    }
  });

  it('has abiguous descriptions', () => {
    for (const item of lexicon.words) {
      expect(item.ambiguousDescription).toBeTruthy();
    }
  });

  it('generates ambiguous dict', () => {
    const results: string[] = lexicon.ambiguousDict['yak'].map(x => x.text);
    expect(results).toContain('ᨿᩣ᩠ᨠ');
    expect(results).toContain('ᩀᩣ᩠ᨠ');
  });

  it('returns relationship', () => {
    const lexicon = new Lexicon();
    const relationship: string[] = lexicon.getRelationship('ᨡᩮᩢ᩶ᩣ').map(x => x.text);
    
    expect(relationship).toContain('ᨡᩮᩢ᩶ᩣᨦᩣ᩠ᨿ');
    expect(relationship).toContain('ᨡᩮᩢ᩶ᩣᨴᩬᩁ');
    expect(relationship).toContain('ᨡᩮᩢ᩶ᩣᩃᩯ᩠ᨦ');
    expect(relationship).toContain('ᩀᩣ᩠ᨠᨡᩮᩢ᩶ᩣ');
  });
});
