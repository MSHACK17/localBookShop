import {Component, Input} from '@angular/core';
import {Book} from "../../models/book";

/**
 * Generated class for the BookComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'book',
  templateUrl: 'book.html'
})
export class BookComponent {

  text: string;

  @Input() book:Book;


  constructor() {
    console.log('Hello BookComponent Component');
    this.text = 'Hello World';
  }

}
