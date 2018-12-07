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
import { AppInjector } from './core/app-injector.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeCategoryComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
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
