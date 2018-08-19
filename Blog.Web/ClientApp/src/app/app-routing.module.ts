import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  exports : [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
]

})
export class AppRoutingModule { }


