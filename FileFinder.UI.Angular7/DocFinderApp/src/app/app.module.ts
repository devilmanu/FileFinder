import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DocFinderModule } from './features/doc-finder/doc-finder.module';
import { SidebarModule } from 'ng-sidebar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SentryErrorHandler } from './core/SentryErrorHandler';
import * as Sentry from "@sentry/browser";


Sentry.init({
  dsn: "https://87ed553fd8a54ba1bb164c66a78c6d2f@sentry.io/1390707"
});

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DocFinderModule,
    BrowserAnimationsModule,
    SidebarModule.forRoot()
  ],
  providers: [
    { provide: ErrorHandler, useClass: SentryErrorHandler }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
