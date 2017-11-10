import { NgModule } from '@angular/core';
import { BookComponent } from './book/book';
import { BookListComponent } from './book-list/book-list';
@NgModule({
	declarations: [BookComponent,
    BookListComponent],
	imports: [],
	exports: [BookComponent,
    BookListComponent]
})
export class ComponentsModule {}
