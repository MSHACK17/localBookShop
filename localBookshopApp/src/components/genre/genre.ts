import {Component, Input} from '@angular/core';
import {NavController} from "ionic-angular";
import {Genre} from "../../models/genre";
/**
 * Generated class for the GenreComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'genre',
  templateUrl: 'genre.html'
})
export class GenreComponent {

  @Input('genres') genres: Genre[];

  constructor(public navController: NavController) {
  }

  goToPage(){

  }

}
