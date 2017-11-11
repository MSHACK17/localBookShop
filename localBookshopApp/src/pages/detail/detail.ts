import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {Book} from "../../models/book";
import {Shop} from "../../models/shop";

/**
 * Generated class for the DetailPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-detail',
  templateUrl: 'detail.html',
})
export class DetailPage {

  book:Book;
  shops: Shop[];

  constructor(public navCtrl: NavController, public navParams: NavParams) {
    this.book = navParams.data.book;
    this.shops= navParams.data.shops;
  };



}
