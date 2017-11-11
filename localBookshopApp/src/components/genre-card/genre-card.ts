import { Component } from '@angular/core';

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

  text: string;

  constructor() {
    console.log('Hello GenreCardComponent Component');
    this.text = 'Hello World';
  }

}
