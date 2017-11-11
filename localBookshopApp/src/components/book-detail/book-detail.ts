import {Component,  Input} from '@angular/core';
import {Book} from "../../models/book";
import {Shop} from "../../models/shop";

import {HttpClient} from "@angular/common/http";

import { ModalController } from 'ionic-angular';
import {ShopDetailPage} from "../../pages/shop-detail/shop-detail";


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



  key:string = '&key=AIzaSyD29ws1Qewk5R_SQgkYRg3_qw8wLiRPWN4';

  lat: number = 51.950139;

  lng: number = 7.638549;

  strokeColor: '#FF0000';
  fillColor: '#FF0000';

  url:string = 'https://maps.googleapis.com/maps/api/distancematrix/json?origins=' + this.lat+','+ this.lng+ '&destinations=';



  @Input() book:Book;
  @Input() shops:Shop[];

  shopObjects:any;

  constructor(private http:HttpClient,public modalCtrl: ModalController) {

  }

  ngAfterContentInit(){
    console.info(this.book);
    this.shopObjects = [];

    this.shops.forEach((shop, position)=> {
      let positionObject = JSON.parse(shop.position);
      if(position==0){
        this.url +=positionObject.lat +","+ positionObject.long;
      }else{
        this.url +='|' + positionObject.lat +","+ positionObject.long;
      }
    });

    this.url +=this.key;
    this.http.get(this.url).subscribe((data) =>{
      console.log(data);
      this.shops.forEach((shop,position)=>{

        this.shopObjects.push({
          id:  shop.id,
          name: shop. name,
          duration: data['rows'][0].elements[position].duration.text,
          durationSort: data['rows'][0].elements[position].duration.value,
          distance: data['rows'][0].elements[position].distance.text,
          city: shop.city,
          zip: shop.zip,
          street: shop.street,
          position: shop.position != null ? JSON.parse(shop.position) : null,
          amount: shop.amount
        })
      })
      this.shopObjects.sort(function (a, b) {
        if (a.durationSort > b.durationSort) {
          return 1;
        }
        if (a.durationSort < b.durationSort) {
          return -1;
        }
        // a muss gleich b sein
        return 0;
      });
      console.log(this.shopObjects);
    });
  }
  showShopDetail(shop:any){
    let modal = this.modalCtrl.create(ShopDetailPage, {shop: shop, book: this.book});
    modal.present();
  };


}
