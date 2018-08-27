import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { AppComponent } from './app.component';
import { BlogComponent } from './blog/blog.component';
import { PostComponent } from './post/post.component';
import { CommentComponent } from './comment/comment.component';
import { AppRoutingModule } from './/app-routing.module';
import { HomeComponent } from './home/home.component';
import { NavigationComponent } from './navigation/navigation.component';


import { EditBlogComponent } from './blog/eidt-blog/edit-blog.component';
import { AddBlogComponent } from './blog/add-blog/add-blog.component';
import { BlogFormComponent } from './blog/blog-form/blog-form.component';

@NgModule({
  declarations: [
    AppComponent,
    BlogComponent,
    PostComponent,
    CommentComponent,
    HomeComponent,
    NavigationComponent,
    AddBlogComponent,
    EditBlogComponent,
    BlogFormComponent,
  ],
  imports: [
    NgbModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
