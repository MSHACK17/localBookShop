import {Component,  Input} from '@angular/core';
import {Book} from "../../models/book";
import {Shop} from "../../models/shop";

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





  @Input() book:Book;
  @Input() shops:Shop[];

  shopObjects:any;


  constructor() {
  }
  ngAfterContentInit(){
    console.info(this.book);
    this.shopObjects = [];

    this.shops.forEach((shop)=>{
      console.log(shop);
      console.log(JSON.parse(shop.position));
      this.shopObjects.push({
        id:  shop.id,
        name: shop. name,
        city: shop.city,
        zip: shop.zip,
        street: shop.street,
        position: shop.position != null ? JSON.parse(shop.position) : null,
        amount: shop.amount
      })
    })

  }
  showShopDetail(shop:any){
    console.info(shop);
  };


}
