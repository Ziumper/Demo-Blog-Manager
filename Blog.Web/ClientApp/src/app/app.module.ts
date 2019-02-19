// Library modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';

// Modules
import { AppRoutingModule } from './/app-routing.module';

// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HomeCategoryComponent } from './home/home-category/home-category.component';

// Services
import { BlogModule } from './blog/blog.module';
import { CoreModule } from './core/core.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeCategoryComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    BlogModule,
    CoreModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private injector: Injector) {

    }
 }
