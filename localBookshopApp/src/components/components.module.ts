import { NgModule } from '@angular/core';
import { SearchComponent } from './search/search';
import { GenreComponent } from './genre/genre';
import { GenreCardComponent } from './genre-card/genre-card';
@NgModule({
	declarations: [SearchComponent,
    GenreComponent,
    GenreCardComponent],
	imports: [],
	exports: [SearchComponent,
    GenreComponent,
    GenreCardComponent]
})
export class ComponentsModule {}
