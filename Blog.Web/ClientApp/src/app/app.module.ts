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
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PostModule } from './post/post.module';
import { NavigationComponent } from './navigation/navigation.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserModule } from './user/user.module';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    BlogModule,
    CoreModule,
    PostModule,
    AngularFontAwesomeModule,
    NgbModule,
    UserModule
  ],
  bootstrap: [AppComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    // { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ]
})
export class AppModule {
  constructor() {

  }
}
