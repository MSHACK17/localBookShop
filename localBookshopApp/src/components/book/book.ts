import {Component, Input} from '@angular/core';
import {Book} from "../../models/book";
import {NavController} from "ionic-angular";
import {DetailPage} from "../../pages/detail/detail";
import {Apollo} from "apollo-angular";
import gql from "graphql-tag";
import {Shop} from "../../models/shop";
import {getLocaleTimeFormat} from "@angular/common";

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
  constructor(public navCtrl: NavController,private apollo: Apollo) {
  }

  showBookDetail(){
    this.apollo.query({
      query: gql`{
        bookById(id:${this.book.id}){
          shops{
            nodes{
              name,
              city,
              zip,
              street,
              position,
              amount
            }
          }
        }
      }`
    }).subscribe(({data, loading}) => {
      let result = data as any;
      let shops = result.bookById.shops.nodes;
      this.navCtrl.push(DetailPage,{book:this.book, shops: shops})
    });
  }

}
