//Library modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

//Modules
import { AppRoutingModule } from './/app-routing.module';

//Services
import { HttpService } from './core/http.service';
import { LoggerService } from './core/logger.service';

//Components
import { AppComponent } from './app.component';
import { BlogComponent } from './blog/blog.component';
import { PostComponent } from './post/post.component';
import { CommentComponent } from './comment/comment.component';
import { HomeComponent } from './home/home.component';
import { NavigationComponent } from './navigation/navigation.component';
import { EditBlogComponent } from './blog/eidt-blog/edit-blog.component';
import { AddBlogComponent } from './blog/add-blog/add-blog.component';
import { BlogFormComponent } from './blog/blog-form/blog-form.component';
import { LoaderComponent } from './core/loader/loader.component';
import { LoaderService } from './core/loader/loader.service';





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
    LoaderComponent
  ],
  imports: [
    NgbModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    FormsModule
  ],
  providers: [
    HttpService,
    LoggerService,
    LoaderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
