import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostFormComponent } from './post/post-form/post-form.component';
import { CategoryFormComponent } from './category/category-form/category-form.component';
import { TagComponent } from './tag/tag.component';
import { PostComponent } from './post/post.component';
import { BlogComponent } from './blog/blog.component';
import { BlogManagerComponent } from './blog/blogs-manager/blog-manager.component';
import { PostsManagerComponent } from './post/posts-manager/posts-manager.component';
import { BlogFormComponent } from './blog/blog-form/blog-form.component';

const routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'blog-manager/:blogId', component: BlogManagerComponent,
    children: [
      { path: '', redirectTo: 'blog-options', pathMatch: 'full' },
      { path: 'blog-options', component: BlogFormComponent },
      { path: 'posts-manager', component: PostsManagerComponent},
      { path: 'post-editor', component: PostFormComponent},
    ]
  },
  { path: 'category-editor', component: CategoryFormComponent},
  { path: 'category-editor/:id', component: CategoryFormComponent},
  { path: 'blog/:blogId', component: BlogComponent },
  { path: 'blog/:blogId/post/:id', component: PostComponent},
  { path: 'tag/:tagId', component: TagComponent},
  { path: 'post-editor/:postId', component: PostFormComponent},
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  exports : [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
]

})
export class AppRoutingModule { }


