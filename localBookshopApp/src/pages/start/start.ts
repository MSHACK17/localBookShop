import {Component} from '@angular/core';
import {IonicPage, NavController, NavParams} from 'ionic-angular';
import {Apollo} from 'apollo-angular';
import gql from 'graphql-tag';
/**
 * Generated class for the StartPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-start',
  templateUrl: 'start.html',
})
export class StartPage {

  constructor(public navCtrl: NavController, public navParams: NavParams, private apollo: Apollo) {
    this.apollo.query({
      query: gql`{
          books:allBooks {
            nodes{
              title
            }
          }
      }`
    }).subscribe(({data, loading}) => {
      this.data = data;
      this.loading = loading;
    });
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad StartPage');
  }

}
