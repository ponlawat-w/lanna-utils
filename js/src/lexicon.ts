import getAmbiguousDescription from './ambiguous-description';
import levenshtein from './utils/levenshtein';
import lexiconData from './resources/lexicon.json';

export class Word {
  public text: string;
  public ambiguousDescription: string;

  public constructor(word: string) {
    this.text = word;
    this.ambiguousDescription = getAmbiguousDescription(this.text);
  }

  public compareWord(word: string): number {
    return levenshtein(this.text, word);
  }

  public compareAmbiguousDescription(ambiguousDescriptionText: string): number {
    return levenshtein(this.ambiguousDescription, ambiguousDescriptionText);
  }
};

export default class Lexicon {
  public readonly words: Word[];
  public readonly ambiguousDict: {[ambiguousDescription: string]: Word[]};
  public readonly ambiguousList: string[];

  public constructor() {
    this.words = lexiconData.map(x => new Word(x));

    this.ambiguousDict = {};
    for (const word of this.words) {
      if (!this.ambiguousDict[word.ambiguousDescription]) {
        this.ambiguousDict[word.ambiguousDescription] = [];
      }
      this.ambiguousDict[word.ambiguousDescription].push(word);
    }
    this.ambiguousList = Object.keys(this.ambiguousDict);
  }

  public getRelationship(word: string): Word[] {
    return this.words.filter(w => w.text.indexOf(word) > -1);
  }
};
