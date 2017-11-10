import {Component} from '@angular/core';
import {NavController} from "ionic-angular";
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

  text: string;

  constructor(public navController: NavController) {
    console.log('Hello GenreComponent Component');
    this.text = 'Hello World';
  }

  goToPage(){

  }

}
