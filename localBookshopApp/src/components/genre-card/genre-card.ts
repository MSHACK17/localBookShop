import {Component, Input} from '@angular/core';
import {Genre} from "../../models/genre";

/**
 * Generated class for the GenreCardComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'genre-card',
  templateUrl: 'genre-card.html'
})
export class GenreCardComponent {

  @Input('genre') genre: Genre;

  constructor() {

  }

}
