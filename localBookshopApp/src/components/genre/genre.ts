import {Component, Input} from '@angular/core';
import {NavController} from "ionic-angular";
import {Genre} from "../../models/genre";
import {Apollo} from "apollo-angular";
import gql from "graphql-tag";
import {SearchResultPage} from "../../pages/search-result/search-result";
/**
 * Generated class for the GenreComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'genre',
  templateUrl: 'genre.html'
})
export class GenreComponent {

  @Input('genres') genres: Genre[];

  constructor(public navController: NavController, private apollo: Apollo) {
  }

  goToPage(genre: Genre){
    this.apollo.query({
      query: gql`{
        genreById(id:${genre.id}) {
          books{
            books: nodes{
              id,
              title,
              description,
              imageUrl,
              publicationDate,
              isbn10
            }
          }
        } 
      }`
    }).subscribe(({data, loading}) => {
      let result = data as any;
      let books = result.genreById.books.books;
      this.navController.push(SearchResultPage,{books:books, resultName: genre.name})
    });

  }

}
