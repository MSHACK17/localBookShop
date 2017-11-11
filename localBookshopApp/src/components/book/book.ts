import {Component, Input} from '@angular/core';
import {Book} from "../../models/book";
import {NavController} from "ionic-angular";
import {DetailPage} from "../../pages/detail/detail";

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
  @Input() book:Book;
  constructor(public navCtrl: NavController) {
  }

  showBookDetail(){
    this.navCtrl.push(DetailPage,this.book);
  }

}
