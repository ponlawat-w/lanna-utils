import axios, { AxiosResponse } from 'axios';
import fs from 'fs';

const url = 'https://raw.githubusercontent.com/ponlawat-w/lanna-lexicon/master/lexicon/raw.txt';

const main = async() => {
  console.log('Fetching lexicon...');
  const response: AxiosResponse<string> = await axios.get(url);
  if (response.status !== 200) {
    throw 'Unable to fetch lexicon';
  }
  fs.writeFileSync('./src/resources/lexicon.txt', response.data);
  console.log('Done');
};

main();
