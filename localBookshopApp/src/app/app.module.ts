import { BrowserModule } from '@angular/platform-browser';
import {ErrorHandler,  NgModule} from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { ListPage } from '../pages/list/list';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import {BookListComponent} from "../components/book-list/book-list";
import {BookComponent} from "../components/book/book";
import {SearchResultPage} from "../pages/search-result/search-result";
import {DetailPage} from "../pages/detail/detail";
import {BookDetailComponent} from "../components/book-detail/book-detail";

import {Apollo, ApolloModule} from "apollo-angular";
import { HttpLinkModule, HttpLink } from 'apollo-angular-link-http';
import {HttpClientModule} from "@angular/common/http";
import { InMemoryCache } from 'apollo-cache-inmemory';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    ListPage,
    BookListComponent,
    BookComponent,
    BookDetailComponent,
    SearchResultPage,
    DetailPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    HttpClientModule,
    ApolloModule,
    HttpLinkModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    ListPage,
    SearchResultPage,
    DetailPage
  ],
  providers: [

    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {
  constructor(
    apollo: Apollo,
    httpLink: HttpLink
  ) {
    apollo.create({
      link: httpLink.create({ uri: 'http://172.16.2.200:5000/graphql' }),
      cache: new InMemoryCache()
    });
  }
}
