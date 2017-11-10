import {Component, Input} from '@angular/core';
import {Book} from "../../models/book";

/**
 * Generated class for the BookListComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'book-list',
  templateUrl: 'book-list.html'
})
export class BookListComponent {

  @Input('books') books: Book[];

  constructor() {
    console.log('Hello BookListComponent Component');
  }

}
