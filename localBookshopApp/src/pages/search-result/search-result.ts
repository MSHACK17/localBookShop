import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {Book} from "../../models/book";
import {SearchResult} from "../../models/searchResult";

/**
 * Generated class for the SearchResultPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-search-result',
  templateUrl: 'search-result.html',
})
export class SearchResultPage {

  books: Book[] = [];
  resultName: string;

  constructor(public navCtrl: NavController, public navParams: NavParams) {
    let searchResult:SearchResult = navParams.data;
    this.books = searchResult.books;
    console.log(this.books)
    this.resultName = searchResult.resultName;
  }

  ionViewDidLoad() {
  }

}
