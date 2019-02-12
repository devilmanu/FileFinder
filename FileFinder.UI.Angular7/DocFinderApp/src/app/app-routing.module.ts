import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DocFinderModule } from './features/doc-finder/doc-finder.module';

const routes: Routes = [
  { path: 'doc', loadChildren: () => DocFinderModule }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
