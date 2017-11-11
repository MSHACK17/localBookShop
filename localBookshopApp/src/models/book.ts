
import {Author} from "./author";
import {Genre} from "./genre";

export interface Book {
  id: number,
  genre: Genre;
  title: string;
  description: string;
  imageUrl: string;
  publicationDate: string;
  isbn10: string,
  authorsbybook: {
    nodes:Author[]
  }
}
