import {Component,  Input} from '@angular/core';
import {Book} from "../../models/book";
import {sharedStylesheetJitUrl} from "@angular/compiler";

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

  title: string = 'Google Maps Addeed Successfully';

  lat: number = 51.950139;

  lng: number = 7.638549;

  strokeColor: '#FF0000';
  fillColor: '#FF0000';

  shop:{title:"test"};




  @Input() book:Book;

  constructor() {
  }
  ngAfterContentInit(){
    console.info(this.book);

  }
  showInfo(shop:any){
    console.info(shop.title);
  }

}
