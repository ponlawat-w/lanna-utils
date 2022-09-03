import characters from './resources/characters';
import patterns from './resources/patterns';

export type SegmentExplanation = {
  valid: boolean,
  central: string,
  centralLeft: string,
  left: string,
  top: string,
  right: string,
  rightTop: string,
  rightBottom: string,
  bottom: string
};

const defaultExplanation = (valid: boolean): SegmentExplanation => ({
  valid,
  central: '',
  centralLeft: '',
  left: '',
  top: '',
  right: '',
  rightTop: '',
  rightBottom: '',
  bottom: ''
});

export default function(segment: string = ''): SegmentExplanation {
  const match = new RegExp(patterns.segmentExplanation).exec(segment);
  if (!match || !match.groups) {
    return defaultExplanation(false);
  }
  const result = defaultExplanation(true);

  result.central = match.groups['central'] ?? '';
  result.centralLeft = match.groups['centralLeft'] ?? '';
  result.left = match.groups['left'] ?? '';
  result.top = (match.groups['top1'] ?? '') + (match.groups['top2'] ?? '');
  result.right = match.groups['right'] ?? '';
  result.rightTop = match.groups['rightTop'] ?? '';
  result.rightBottom = (match.groups['rightBottom'] ?? '').replace(new RegExp(characters.signSakot, 'g'), '');
  result.bottom = (match.groups['bottom1'] ?? '').replace(new RegExp(characters.signSakot, 'g'), '')
    + (match.groups['bottom2'] ?? '').replace(new RegExp(characters.signSakot, 'g'), '')
    + (match.groups['bottom3'] ?? '').replace(new RegExp(characters.signSakot, 'g'), '');
  
    if (result.central === characters.letterNa && result.right === characters.vowelSignAa) {
      result.central = characters.letterNa + characters.vowelSignAa;
      result.right = '';
      result.bottom += result.rightBottom;
      result.rightBottom = '';
    }

  return result;
};
