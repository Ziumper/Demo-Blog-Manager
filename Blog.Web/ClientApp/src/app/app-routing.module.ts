import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BlogsManagerComponent } from './blog/blogs-manager/blogs-manager.component';
import { PostFormComponent } from './post/post-form/post-form.component';
import { BlogFormComponent } from './blog/blog-form/blog-form.component';


const routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'blogs-manager', component: BlogsManagerComponent},
  { path: 'add-blog', component: BlogFormComponent },
  { path: 'add-post', component: PostFormComponent},
  { path: 'edit-post/:id', component: PostFormComponent},
  { path: 'edit-blog/:id', component: BlogFormComponent },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  exports : [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
]

})
export class AppRoutingModule { }


