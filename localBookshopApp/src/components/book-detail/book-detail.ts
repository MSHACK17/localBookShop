import {Component, Input} from '@angular/core';
import {Book} from "../../models/book";
import {NavParams} from "ionic-angular";

/**
 * Generated class for the BookDetailComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'book-detail',
  templateUrl: 'book-detail.html'
})
export class BookDetailComponent {

  @Input() book:Book;

  constructor() {
  }

}
