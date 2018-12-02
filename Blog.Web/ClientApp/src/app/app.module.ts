// Library modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

// Modules
import { AppRoutingModule } from './/app-routing.module';
import { BlogMoudle } from './blog/blog.module';
import { PostModule } from './post/post.module';
import { CoreModule } from './core/core.module';
import { TagModule } from './tag/tag.module';
import { CategoryModule } from './category/category.module';

// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AppInjector } from './core/app-injector.service';
import { CommentModule } from './post/comment/comment.module';
import { HomeCategoryComponent } from './home/home-category/home-category.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeCategoryComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    BlogMoudle,
    PostModule,
    CoreModule,
    TagModule,
    CategoryModule,
    CommentModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private injector: Injector) {
      // Store module's injector in the AppInjector class
      console.log('Expected #1: storing app injector');
      AppInjector.setInjector(injector);
    }
 }
