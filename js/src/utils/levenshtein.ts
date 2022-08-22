export default function (str1: string, str2: string): number {
  const matrix: number[][] = Array(str2.length + 1).fill(null).map(() => Array(str1.length + 1).fill(null));
  for (let i = 0; i <= str1.length; i++) {
    matrix[0][i] = i;
  }
  for (let j = 0; j <= str2.length; j++) {
    matrix[j][0] = j;
  }

  for (let i = 1; i <= str1.length; i++) {
    for (let j = 1; j <= str2.length; j++) {
      matrix[j][i] = Math.min(
        matrix[j][i - 1] + 1,
        matrix[j - 1][i] + 1,
        matrix[j - 1][i - 1] + (str1[i - 1] === str2[j - 1] ? 0 : 1)
      );
    }
  }

  return matrix[str2.length][str1.length];
}
