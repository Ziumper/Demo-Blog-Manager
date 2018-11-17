// Library modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

// Modules
import { AppRoutingModule } from './/app-routing.module';
import { BlogMoudle } from './blog/blog.module';
import { PostModule } from './post/post.module';
import { CoreModule } from './core/core.module';

// Components
import { AppComponent } from './app.component';
import { CommentComponent } from './comment/comment.component';
import { HomeComponent } from './home/home.component';
import { NavigationComponent } from './navigation/navigation.component';
import { TagModule } from './tag/tag.module';


@NgModule({
  declarations: [
    AppComponent,
    CommentComponent,
    HomeComponent,
    NavigationComponent,
  ],
  imports: [
    NgbModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    BlogMoudle,
    PostModule,
    CoreModule.forRoot(),
    TagModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
