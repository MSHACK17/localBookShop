import { NgModule } from '@angular/core';
import { BookComponent } from './book/book';
import { BookListComponent } from './book-list/book-list';
import { BookDetailComponent } from './book-detail/book-detail';
@NgModule({
	declarations: [BookComponent,
    BookListComponent,
    BookDetailComponent],
	imports: [],
	exports: [BookComponent,
    BookListComponent,
    BookDetailComponent]
})
export class ComponentsModule {}
