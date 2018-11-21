import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BlogsManagerComponent } from './blog/blogs-manager/blogs-manager.component';
import { PostFormComponent } from './post/post-form/post-form.component';
import { BlogFormComponent } from './blog/blog-form/blog-form.component';
import { CategoryFormComponent } from './category/category-form/category-form.component';
import { TagComponent } from './tag/tag.component';

const routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'blogs-manager', component: BlogsManagerComponent},
  { path: 'blog-editor', component: BlogFormComponent },
  { path: 'category-editor', component: CategoryFormComponent},
  { path: 'category-editor/:id', component: CategoryFormComponent},
  { path: 'post-editor/:blogId', component: PostFormComponent},
  { path: 'post-editor/:blogId/:id', component: PostFormComponent},
  { path: 'blog-editor/:id', component: BlogFormComponent },
  { path: 'tag/:tagId',component: TagComponent},
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  exports : [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
]

})
export class AppRoutingModule { }


