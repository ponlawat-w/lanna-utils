import { fixTextExpressions, fixSegmentExpressions } from './resources/fix-expressions.json';
import textSegment from './text-segment';

type ExpressionRaw = {pattern: string, replace: string};
type Expression = {pattern: RegExp, replace: string};

const createExpression = (raw: ExpressionRaw): Expression => ({pattern: new RegExp(raw.pattern), replace: raw.replace});

const applyExpressions = (text: string, expressions: Expression[]): string => expressions.reduce(
  (str, exp) => str.replace(exp.pattern, exp.replace), text
);

const textExpressions: Expression[] = fixTextExpressions.map(createExpression);
const segmentExpressions: Expression[] = fixSegmentExpressions.map(createExpression);

export default function(input: string): string {
  return textSegment(applyExpressions(input, textExpressions)).map(segment => applyExpressions(segment, segmentExpressions)).join('');
};
