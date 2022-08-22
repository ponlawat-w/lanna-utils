import getAmbiguousDescription from './ambiguous-description';
import fixOrder from './fix-order';
import Lexicon, { Word } from './lexicon';
import textSegment from './text-segment';
import levenshtein from './utils/levenshtein';

export type SuggestionResult = {
  text: string,
  remaining: string
};

export type SuggestedItem = {
  text: string,
  remaining: string,
  distance: number,
  ambiguousDistance: number
};

export type Segment = {
  segment: string,
  ambiguousDescription: string
};

export type Suffix = {
  text: string,
  ambiguousDescription: string
};

export type SuggestedAmbiguous = {
  description: string,
  distance: number
};

export type SuggestedWord = {
  word: Word,
  ambiguousDistance: number
};

export class ResultSet {
  private resultsMap: {[text: string]: SuggestedItem};
  public get length(): number {
    return Object.keys(this.resultsMap).length;
  }

  public constructor() {
    this.resultsMap = {};
  }

  public add(item: SuggestedItem) {
    if (this.resultsMap[item.text]) {
      if (item.ambiguousDistance < this.resultsMap[item.text].ambiguousDistance) {
        this.resultsMap[item.text] = item;
      }
      return;
    }
    this.resultsMap[item.text] = item;
  }

  public output(count: number): SuggestionResult[] {
    return Object.keys(this.resultsMap).map(x => this.resultsMap[x])
      .sort((a, b) => this.score(a) - this.score(b))
      .slice(0, count)
      .map(x => ({text: x.text, remaining: x.remaining}));
  }

  private score(item: SuggestedItem): number {
    return item.remaining.length + item.ambiguousDistance + item.distance;
  }
}

export default class Suggestion {
  private lexicon: Lexicon;
  
  public returnCount: number = 100;
  public searchCount: number = 1000;
  public ambiguousLengthTolerance: number = 3;
  public levenshteinFractionTolerance: number = 0.5;

  public constructor() {
    this.lexicon = new Lexicon();
  }

  public suggest(text: string): SuggestionResult[] {
    if (!text) {
      return [];
    }

    const results = new ResultSet();

    text = fixOrder(text);
    const segments: Segment[] = this.getSegments(text);
    for (let i = segments.length; i > 0 && results.length < this.searchCount; i--) {
      const searchSegments = segments.slice(0, i);
      const remaining = segments.slice(i);
      this.processSegments(searchSegments, remaining, results);
    }

    return results.output(this.returnCount);
  }

  private processSegments(segments: Segment[], remaining: Segment[], resultSet: ResultSet) {
    const search: string = segments.map(x => x.ambiguousDescription).join('');
    const suggestedWords: SuggestedWord[] = this.searchLexicon(search);
    for (const suggestedWord of suggestedWords) {
      resultSet.add({
        text: suggestedWord.word.text,
        remaining: remaining.map(x => x.segment).join(''),
        distance: suggestedWord.word.compareWord(segments.map(x => x.segment).join('')),
        ambiguousDistance: suggestedWord.ambiguousDistance
      });
    }
  }

  private searchLexicon(ambiguousDescription: string): SuggestedWord[] {
    const minAmbiguousLength: number = Math.max(0, ambiguousDescription.length - this.ambiguousLengthTolerance);
    const maxAmbiguousLength: number = ambiguousDescription.length + this.ambiguousLengthTolerance;
    const suggestedAmbiguouses: SuggestedAmbiguous[] = this.lexicon.ambiguousList
      .filter(x => x.length >= minAmbiguousLength && x.length <= maxAmbiguousLength)
      .map(x => ({description: x, distance: levenshtein(ambiguousDescription, x)}))
      .filter(x => x.distance / ambiguousDescription.length <= this.levenshteinFractionTolerance);
    const results: SuggestedWord[] = [];
    for (const suggestedAmbiguous of suggestedAmbiguouses) {
      const words = this.lexicon.ambiguousDict[suggestedAmbiguous.description];
      for (const word of words) {
        results.push({word: word, ambiguousDistance: suggestedAmbiguous.distance});
      }
    }
    return results;
  }

  private getSegments(text: string): Segment[] {
    return textSegment(text).map(segment => ({segment, ambiguousDescription: getAmbiguousDescription(segment)}));
  }
}
