
import {Author} from "./author";
import {Genre} from "./genre";

export interface Book {
  author: Author;
  genre: Genre;
  titel: string;
  description: string;
  picture: string;
  releaseDate: string;
}
