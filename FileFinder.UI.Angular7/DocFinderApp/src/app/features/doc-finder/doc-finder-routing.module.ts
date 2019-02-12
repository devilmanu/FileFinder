import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DocFinderComponent } from './pages/doc-finder/doc-finder.component';

const routes: Routes = [
  { path: 'search', component : DocFinderComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DocFinderRoutingModule { }
