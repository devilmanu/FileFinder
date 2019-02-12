import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { DocFinderRoutingModule } from './doc-finder-routing.module';
import { DocFinderComponent } from './pages/doc-finder/doc-finder.component';
import { FileFinderService } from './services/file-finder.service';
import { HttpClientModule } from '@angular/common/http';
import { SidebarModule } from 'ng-sidebar';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { HighlightColorDirective } from './directives/highlight-color.directive';

@NgModule({
  declarations: [DocFinderComponent, HighlightColorDirective],
  imports: [
    CommonModule,
    DocFinderRoutingModule,
    HttpClientModule,
    SidebarModule.forRoot(),
    ReactiveFormsModule,
    NgxPaginationModule,
    PerfectScrollbarModule,
  ],
  providers : [FileFinderService]
})
export class DocFinderModule { }
