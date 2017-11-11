import {Component} from '@angular/core';
import {IonicPage, NavController, NavParams} from 'ionic-angular';
import {Apollo} from 'apollo-angular';
import gql from 'graphql-tag';
import {Genre} from "../../models/genre";
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

  genres: Genre[];

  constructor(private apollo: Apollo) {
    this.apollo.query({
      query: gql`{
          genres:allGenres {
            nodes{
              id,
              name,
              imageUrl
            }
          }
      }`
    }).subscribe(({data, loading}) => {
      let result = data as any;
      this.genres = result.genres.nodes;
    });
  }

  ionViewDidLoad() {
  }

}
