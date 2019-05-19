// Library modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';
// Modules
import { AppRoutingModule } from './/app-routing.module';
// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
// Services
import { BlogModule } from './blog/blog.module';
import { CoreModule } from './core/core.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PostModule } from './post/post.module';
import { TagModule } from './tag/tag.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    BlogModule,
    CoreModule,
    PostModule,
    TagModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {

  }
}
