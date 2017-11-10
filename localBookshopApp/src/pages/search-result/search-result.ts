import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {Book} from "../../models/book";

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

  constructor(public navCtrl: NavController, public navParams: NavParams) {
  }

  ionViewDidLoad() {
    this.books = [{
      genre:null,
      author: {
        name:"Angela Merkel"
      },
      description:"»Sie kennen mich« – mit diesem Spruch warb Angela Merkel vor vier Jahren für ihre Wiederwahl. Doch wer ist Merkel wirklich? Was sind ihre Verdienste, was waren ihre größten Fehler? In diesem Buch ziehen 22 Professoren und Publizisten eine Bilanz der Ära Merkel. Der Herausgeber, FAZ-Redakteur Philip Plickert, hat renommierte Autoren versammelt, die das politische Wirken und die Person Merkels analysieren.",
      picture:"https://images-na.ssl-images-amazon.com/images/I/513YRKNWzhL._SX352_BO1,204,203,200_.jpg",
      titel:"Merkel: Eine kritische Bilanz",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"test",
      titel:"test",
      releaseDate:"2017-05-06"
    },{
      genre:null,
      author: null,
      description:"test",
      picture:"Wait a minute. Wait a minute, Doc. Uhhh... Are you telling me that you built a time machine... out of a DeLorean?! Whoa. This is heavy.",
      titel:"test",
      releaseDate:"2017-05-06"
    }];
  }

}
