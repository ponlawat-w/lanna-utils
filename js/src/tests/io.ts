import { createReadStream } from "fs";
import { parse } from 'csv';

export function readCsv<T>(path: string, mapFn: (row: {[column: string]: any}) => T): Promise<T[]> {
  return new Promise<T[]>((resolve, reject) => {
    const results: T[] = [];
    createReadStream(path).pipe(parse({columns: true})).on('data', row => {
      results.push(mapFn(row));
    }).on('end', () => {
      resolve(results);
    }).on('error', err => reject(err));
  });
};
