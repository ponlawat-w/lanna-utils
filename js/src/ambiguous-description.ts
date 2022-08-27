import resources from './resources/ambiguous-description';
import textSegment from './text-segment';

const initialRegexPattern = resources.initialRegex;
const vowelRegexPattern = resources.vowelRegex;
const finalRegexPattern = resources.finalRegex;
const compoundVowelPatterns = resources.compoundVowelPatterns;
const letterValues = resources.letterValues;
const specialValues = resources.specialValues;

const getLetterValue = (letter: string): string => (letterValues as any)[letter] ?? '?';
const getSpecialValue = (letter: string): string => (specialValues as any)[letter] ?? '?';

const getInitial = (segment: string): {result: string, remaining: string} => {
  const regex = new RegExp(initialRegexPattern, 'gu');
  const match = regex.exec(segment);
  if (!match || !match.groups) {
    return {result: '', remaining: segment};
  }

  if (match.groups['special']) {
    return {result: getSpecialValue(match.groups['special']), remaining: ''};
  }

  let result = '';
  if (match.groups['haCombination']) {
    result += getLetterValue(match.groups['afterHaLetter']);
  } else if (match.groups['singleInitial']) {
    result += getLetterValue(match.groups['singleInitial']);
  } else if (match.groups['compoundInitial']) {
    result += getLetterValue(match.groups['compoundMain']);
    let choengMatch: RegExpExecArray|null = match;
    do {
      result += (choengMatch && choengMatch.groups) ? getLetterValue(choengMatch.groups['compoundChoengLetter'] ?? '') : '';
    }
    while (choengMatch = regex.exec(segment));
  }

  if (match.groups['leftComponent']) {
    result += getLetterValue(match.groups['leftComponent']);
  }
  if (match.groups['lowerComponent']) {
    result += getLetterValue(match.groups['lowerComponent']);
  }

  return {result: result, remaining: match.groups['remaining'] ?? ''};
};

const getVowel = (processedSegment: string): {result: string, remaining: string} => {
  const match = new RegExp(vowelRegexPattern, 'gu').exec(processedSegment);

  if (match && match.groups) {
    if (match.groups['compound']) {
      for (const compoundVowelPattern of compoundVowelPatterns) {
        if (match.groups[compoundVowelPattern.GroupName]) {
          return {result: compoundVowelPattern.AmbiguousValue, remaining: match.groups['remaining'] ?? ''}
        }
      }
    } else if (match.groups['single']) {
      return {result: getLetterValue(match.groups['singleVowel']), remaining: match.groups['remaining'] ?? ''};
    }
  }

  return {result: '', remaining: ''};
};

const getFinal = (processedSegment: string): string => {
  const regex = new RegExp(finalRegexPattern, 'gu');
  const match = regex.exec(processedSegment);
  if (!match || !match.groups) {
    return '';
  }

  let result = '';
  if (match.groups['any1']) {
    result += getLetterValue(match.groups['any1']);
  }
  if (match.groups['choeng']) {
    let choengMatch: RegExpExecArray|null = match;
    do {
      result += choengMatch && choengMatch.groups ? getLetterValue(choengMatch.groups['choengLetters'] ?? '') : '';
    } while (choengMatch = regex.exec(processedSegment));
  }
  if (match.groups['any2']) {
    result += getLetterValue(match.groups['any2']);
  }

  return result;
};

const describeSegment = (segment: string): string => {
  const initial = getInitial(segment);
  const vowel = getVowel(initial.remaining);
  const final = getFinal(vowel.remaining);
  return initial.result + vowel.result + final;
};

export default function (text: string): string {
  return textSegment(text).map(describeSegment).join('');
}
