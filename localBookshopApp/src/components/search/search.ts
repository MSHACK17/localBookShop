import { Component } from '@angular/core';
import {Apollo} from "apollo-angular";
import {NavController} from "ionic-angular";
import gql from "graphql-tag";
import {SearchResultPage} from "../../pages/search-result/search-result";

/**
 * Generated class for the SearchComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'search',
  templateUrl: 'search.html'
})
export class SearchComponent {

  searchTerm: string;

  constructor(public navController: NavController, private apollo: Apollo) {
  }

  search(searchTerm: string){
    this.apollo.query({
      query: gql`{       
        search(searchterm:"${searchTerm}") {
            books:nodes {
              id,
              title,
              description,
              imageUrl,
              publicationDate,
              isbn10
            }
        }
      }`
    }).subscribe(({data, loading}) => {
      let result = data as any;
      let books = result.search.books;
      this.navController.push(SearchResultPage,{books:books, resultName: "Ergebnisse"})
    });
  }


}
