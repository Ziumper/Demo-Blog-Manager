import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostFormComponent } from './post/post-form/post-form.component';
import { TagComponent } from './tag/tag.component';
import { PostComponent } from './post/post.component';
import { BlogComponent } from './blog/blog.component';
import { BlogManagerComponent } from './blog/blog-manager/blog-manager.component';
import { PostsManagerComponent } from './post/posts-manager/posts-manager.component';
import { BlogFormComponent } from './blog/blog-form/blog-form.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { ProfileComponent } from './user/profile/profile.component';

const routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'login', component: LoginComponent},
  { path: 'profile', component: ProfileComponent},
  { path: 'blog-manager/:blogId', component: BlogManagerComponent,
    children: [
      { path: '', redirectTo: 'blog-options', pathMatch: 'full' },
      { path: 'blog-options', component: BlogFormComponent },
      { path: 'posts-manager', component: PostsManagerComponent},
      { path: 'post-form', component: PostFormComponent},
    ]
  },
  { path: 'blog/:blogId', component: BlogComponent },
  { path: 'blog/:blogId/post/:id', component: PostComponent},
  { path: 'tag/:tagId', component: TagComponent},
  { path: 'blog/:blogId/post-form/:id', component: PostFormComponent},
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  exports : [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
]

})
export class AppRoutingModule { }


